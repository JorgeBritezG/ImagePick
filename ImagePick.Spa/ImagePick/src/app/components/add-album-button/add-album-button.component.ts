import { Component, Input, OnInit } from '@angular/core';
import { Album } from 'src/app/models/album';
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

  private controller = 'Albums'
  album: Album | undefined;


  constructor(
    private apiService: ApiService,
  ) {
   }

  ngOnInit(): void {
        
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
