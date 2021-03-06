import { AfterViewInit, Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import { Album } from 'src/app/models/album';
import { Image } from 'src/app/models/image';
import { UserToken } from 'src/app/models/user-token';
import { ApiService } from 'src/app/providers/api.service';
import { JwtService } from 'src/app/providers/jwt.service';
import { LikedService } from 'src/app/providers/liked.service';

@Component({
  selector: 'app-like-button',
  templateUrl: './like-button.component.html',
  styleUrls: ['./like-button.component.css']
})
export class LikeButtonComponent implements OnInit, AfterViewInit {
  @Input() image: any | undefined;
  @Input() albums: Album[] | null = [];
  user: UserToken | null | undefined;


  liked$: Observable<boolean>;

  constructor(
    private apiService: ApiService,
    private likeService: LikedService,
    private router: Router,
    private jwtService: JwtService,
  ) { 
    this.liked$ = this.likeService.liked$.pipe(
      filter(f => f.imageId === this.image.id),
      map(x => x.like )
    );
  }

  ngOnInit(): void {

    this.user = this.jwtService.getUser();

  }

  ngAfterViewInit() {

    setTimeout(() => {

      if (this.user) {
 
        this.getImageLikes(this.albums);

      }
      
    }, 400);


  }

 
  getImageLikes(albums: Album[] | null) {

    if (albums) {
      const likeAlbumId = albums.find(x => x.name === 'Me Gusta')?.id;
  
      if(likeAlbumId){
        const imageId = this.image.id;
        this.apiService.getById(`Images/liked/${imageId}`, likeAlbumId.toString() )
        .subscribe(
          (like: boolean) => {
            if(like) {
              this.likeService.like(imageId);
            }  else {
              this.likeService.unLike(imageId);
            } 
          },
          error => console.log(error)
        );
      } 
    } else {
      this.getImageLikes(this.albums);
    }
    
  }

  addLike() {

    if (this.user) {

      const album = this.albums?.find(x => x.name === 'Me Gusta');
  
      this.apiService.getById('Images', this.image.id).subscribe( (image: Image) => {
        if (image) {
          const imageToUpdate: Image = {
            id: image.id,
            regularUrl: image.regularUrl,
            smallUrl: image.smallUrl,
            thumbUrl: image.thumbUrl,
            userHtmlLink: image.userHtmlLink,
            userName: image.userName,
            userProfileImageSmall: image.userProfileImageSmall,
            albumId: album?.id,
          }
  
          this.apiService.update(imageToUpdate, 'Images').subscribe(z => {
            this.likeService.like(this.image.id);
          }, error => this.likeService.unLike(this.image.id))
        } else {
          const image: Image = {
            id: this.image.id,
            regularUrl: this.image.urls.regular,
            smallUrl: this.image.urls.small,
            thumbUrl: this.image.urls.thumb,
            userName: this.image.user.name,
            userProfileImageSmall: this.image.user.profile_image.small,
            userHtmlLink: this.image.user.links.html,
            albumId: album?.id,
          }
      
          this.apiService.create(image, 'Images').subscribe(x => {
            this.likeService.like(this.image.id);
          });
        }
        
  
  
      }, error => {
        console.log(error);
        this.likeService.unLike(this.image.id);
      });

    } else {
      this.router.navigate(['/login']);
    }

    
  }

  

}
