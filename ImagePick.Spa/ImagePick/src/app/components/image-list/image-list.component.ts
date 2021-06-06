import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Album } from 'src/app/models/album';
import { UserToken } from 'src/app/models/user-token';
import { ApiService } from 'src/app/providers/api.service';
import { AuthenticateService } from 'src/app/providers/authenticate.service';
import { GetImagesService } from 'src/app/providers/get-images.service';

@Component({
  selector: 'app-image-list',
  templateUrl: './image-list.component.html',
  styleUrls: ['./image-list.component.css']
})
export class ImageListComponent implements OnInit {

  images$: Observable<any[]> | undefined;
  album$: Observable<Album[]> | undefined;
  user: UserToken | null | undefined;


  constructor(
    private getImages: GetImagesService,
    private apiService: ApiService,
    private authService: AuthenticateService,

  ) {    
    
  }

  ngOnInit(): void {
    this.images$ = this.getImages.getAll();

    this.authService.currentUser.subscribe((user) => {
      if (user) {
          
        this.user = user;
        this.album$ = this.apiService.getAll(`Albums/by-user/${user?.userId}`);

      }

    }, error => console.error(error))
  }

}
