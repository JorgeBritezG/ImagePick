import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Album } from 'src/app/models/album';
import { UserToken } from 'src/app/models/user-token';
import { ApiService } from 'src/app/providers/api.service';
import { AuthenticateService } from 'src/app/providers/authenticate.service';

@Component({
  selector: 'app-add-album-button',
  templateUrl: './add-album-button.component.html',
  styleUrls: ['./add-album-button.component.css']
})
export class AddAlbumButtonComponent implements OnInit {
  @Input() albums: Album[] | null = [];

  private controller = 'Albums'
  album: Album | undefined;
  user: UserToken | undefined;


  constructor(
    private apiService: ApiService,
    private authService: AuthenticateService,
  ) {
   }

  ngOnInit(): void {
    this.authService.currentUser.subscribe(
      user => this.user = user ?? undefined,
      error => console.error(error)      
    )
    
  }

  addAlbum(name: string) {

    this.album = {
      createdAt: new Date(),
      name,
      userId: this.user?.userId || undefined,
    }
    
    this.apiService.create(this.album, this.controller).subscribe(x => {
      console.log(x);

    })

  }

}
