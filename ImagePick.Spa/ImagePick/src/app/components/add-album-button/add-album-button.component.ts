import { Component, Input, OnInit } from '@angular/core';
import { Album } from 'src/app/models/album';
import { Image } from 'src/app/models/image';
import { UserToken } from 'src/app/models/user-token';
import { ApiService } from 'src/app/providers/api.service';

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
  ) {
    
   }

  ngOnInit(): void {
    this.apiService.getById('Images', this.image.id).subscribe(image => {
      console.log('image', image);
      this.imageApi = image;
    })
  }

  addAlbum(name: string) {

    this.album = {
      createdAt: new Date(),
      name,
      userId: this.user?.userId || undefined,
    }
    
    this.apiService.create(this.album, this.controller).subscribe((album: Album) => {

      console.log('album', album);

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

    })
  }

  addImageToAlbum(album: Album) {

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
      console.log(x);
    })
  }

}
  