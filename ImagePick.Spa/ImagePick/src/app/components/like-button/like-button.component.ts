import { Component, Input, OnInit } from '@angular/core';
import { Album } from 'src/app/models/album';
import { Image } from 'src/app/models/image';
import { ApiService } from 'src/app/providers/api.service';

@Component({
  selector: 'app-like-button',
  templateUrl: './like-button.component.html',
  styleUrls: ['./like-button.component.css']
})
export class LikeButtonComponent implements OnInit {
  @Input() image: any | undefined;
  @Input() albums: Album[] | null = [];


  likeAlbumId: number = 0;


  liked = false;

  constructor(
    private apiService: ApiService,
  ) { }

  ngOnInit(): void {

    
    setTimeout(() => {
      this.likeAlbumId = this.albums?.find(x => x.name === 'Me Gusta')?.id ?? 0;

      this.apiService.getById(`Images/liked/${this.image.id}`, this.likeAlbumId.toString() ).subscribe( liked => {
        this.liked = liked
      }, error => this.liked = false);      
    }, 400);

  }

  addLike() {
    
    const album = this.albums?.find(x => x.name === 'Me Gusta');

    this.apiService.getById('Images', this.image.id).subscribe( (image: Image) =>{
      console.log(image);
      image.albumId = album?.id;
      this.apiService.update(image, 'Images').subscribe(z => {
        console.log(z);
        this.liked = true;
      });


    }, error => {
      if (error.status === 404) {
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
          this.liked = true;
        })
      } else{
        console.log(error);
      }
    })
    
  }

  

}
