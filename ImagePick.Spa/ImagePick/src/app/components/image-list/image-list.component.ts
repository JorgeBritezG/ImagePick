import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Album } from 'src/app/models/album';
import { UserToken } from 'src/app/models/user-token';
import { ApiService } from 'src/app/providers/api.service';
import { GetImagesService } from 'src/app/providers/get-images.service';
import { JwtService } from 'src/app/providers/jwt.service';

@Component({
  selector: 'app-image-list',
  templateUrl: './image-list.component.html',
  styleUrls: ['./image-list.component.css']
})
export class ImageListComponent implements OnInit {

  images$: Observable<any[]> | undefined;
  album$: Observable<Album[]> | undefined;
  user: UserToken | null | undefined;
  albums: Album[] = [];


  constructor(
    private getImages: GetImagesService,
    private apiService: ApiService,
    private jwtService: JwtService,

  ) {    
    
  }

  ngOnInit(): void {
    this.images$ = this.getImages.getAll();
    
    this.user = this.jwtService.getUser();
    if (this.user) {
      this.album$ = this.apiService.getAll(`Albums/by-user/${this.user.userId}`);

      this.album$.subscribe(x => this.albums = x);

    }
  }

}
