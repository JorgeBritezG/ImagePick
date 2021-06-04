import { Component, Input, OnInit } from '@angular/core';
import { Album } from 'src/app/models/album';
import { Image } from 'src/app/models/image';
import { ApiService } from 'src/app/providers/api.service';
import { LikedService } from 'src/app/providers/liked.service';

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
    private likeService: LikedService,
  ) { 
  }

  ngOnInit(): void {

    
    setTimeout(() => {
      this.likeAlbumId = this.albums?.find(x => x.name === 'Me Gusta')?.id ?? 0;

      this.apiService.getById(`Images/liked/${this.image.id}`, this.likeAlbumId.toString() )
        .subscribe((like: boolean) => like ? this.likeService.like(this.image.id) : this.likeService.unLike(this.image.id) );

    }, 400);

    this.likeService.liked$.subscribe(like => {
      if(this.image.id === like.imageId) {
        this.liked = like.like;
      }
    })

  }

  addLike() {
    
    const album = this.albums?.find(x => x.name === 'Me Gusta');

    this.apiService.getById('Images', this.image.id).subscribe( (image: Image) =>{
      console.log(image);
      image.albumId = album?.id;
      this.apiService.update(image, 'Images').subscribe(z => {
        console.log(z);
        this.likeService.like(this.image.id);
      }, error => this.likeService.unLike(this.image.id))


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
          this.likeService.like(this.image.id);
        })
      } else{
        console.log(error);
        this.likeService.unLike(this.image.id);
      }
    })
    
  }

  

}
