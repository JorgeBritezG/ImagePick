import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError, filter } from 'rxjs/operators';
import { Album } from 'src/app/models/album';
import { Image } from 'src/app/models/image';
import { UserToken } from 'src/app/models/user-token';
import { ApiService } from 'src/app/providers/api.service';
import { LikedService } from 'src/app/providers/liked.service';

@Component({
  selector: 'app-add-album-button',
  templateUrl: './add-album-button.component.html',
  styleUrls: ['./add-album-button.component.css']
})
export class AddAlbumButtonComponent implements OnInit {
  @Input() albums: Album[] | null = [];
  @Input() user: UserToken | null | undefined;
  @Input() image: any | undefined;
  
  imageApi: Image | undefined;

  private controller = 'Albums'
  album: Album | undefined;


  constructor(
    private apiService: ApiService,
    private likeService: LikedService,
    private router: Router
  ) {
    
   }

  ngOnInit(): void {
    
    this.getImageApi();

    this.likeService.liked$.pipe(
      filter(x => x.imageId === this.image.id)
    ).subscribe( x => {
      if (x.like) {
        this.getImageApi();
      }
    })

  }

  getImageApi() {
    this.apiService.getById('Images', this.image.id).pipe(
      filter(x => x !== null)
    ).subscribe(image => {
      this.imageApi = image;
    }, error => console.error(error))
  }

  addAlbum(name: string) {

    if (this.user) {
      this.album = {
      createdAt: new Date(),
      name,
      userId: this.user?.userId || undefined,
      }
    
      this.apiService.create(this.album, this.controller).subscribe((album: Album) => {

        if (this.imageApi){

          const image: Image = {
            id: this.imageApi.id,
            regularUrl: this.imageApi.regularUrl,
            smallUrl: this.imageApi.smallUrl,
            thumbUrl: this.imageApi.thumbUrl,
            userName: this.imageApi.userName,
            userProfileImageSmall: this.imageApi.userProfileImageSmall,
            userHtmlLink: this.imageApi.userHtmlLink,
            albumId: album.id,
          }
          
          this.apiService.update( image, 'Images').subscribe(y => {

            if (this.imageApi?.album?.name === 'Me Gusta') {
              this.likeService.unLike(this.imageApi.id);
            }
          })  
        } else {
          const image: Image = {
            id: this.image.id,
            regularUrl: this.image.urls.regular,
            smallUrl: this.image.urls.small,
            thumbUrl: this.image.urls.thumb,
            userName: this.image.user.name,
            userProfileImageSmall: this.image.user.profile_image.small,
            userHtmlLink: this.image.user.links.html,
            albumId: album.id,
          }
    
          this.apiService.create( image, 'Images').subscribe(y => {
            console.log('image', y);
          })
        }

      })

    } else {
      this.router.navigate(['/login']);
    }

    
  }

  addImageToAlbum(album: Album) {

    if (this.imageApi) {

      const imageToUpdate: Image = {
        id: this.imageApi.id,
        regularUrl: this.imageApi.regularUrl,
        smallUrl: this.imageApi.smallUrl,
        thumbUrl: this.imageApi.thumbUrl,
        userHtmlLink: this.imageApi.userHtmlLink,
        userName: this.imageApi.userName,
        userProfileImageSmall: this.imageApi.userProfileImageSmall,
        albumId: album.id,
      }
      
      this.apiService.update( imageToUpdate , 'Images').subscribe(y => {

        this.imageApi = y;
        if (album.name === 'Me Gusta') {
          if (this.imageApi)
            this.likeService.like(this.imageApi.id);
        } else {
          if (this.imageApi)
            this.likeService.unLike(this.imageApi.id);
        }
      })
    } else {

      const image: Image = {
        id: this.image.id,
        regularUrl: this.image.urls.regular,
        smallUrl: this.image.urls.small,
        thumbUrl: this.image.urls.thumb,
        userName: this.image.user.name,
        userProfileImageSmall: this.image.user.profile_image.small,
        userHtmlLink: this.image.user.links.html,
        albumId: album.id,
      }
  
      this.apiService.create(image, 'Images').subscribe(x => {
        this.imageApi = x;
        if (album.name === 'Me Gusta') {
            this.likeService.like(x.id);
        }
      })

    }
  }

}
  