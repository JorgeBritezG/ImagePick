import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Album } from 'src/app/models/album';
import { ApiService } from 'src/app/providers/api.service';
import { GetImagesService } from 'src/app/providers/get-images.service';

@Component({
  selector: 'app-image-list',
  templateUrl: './image-list.component.html',
  styleUrls: ['./image-list.component.css']
})
export class ImageListComponent implements OnInit {

  images$: Observable<any[]> | undefined;
  album$: Observable<Album[]>;


  constructor(
    private getImages: GetImagesService,
    private apiService: ApiService,

  ) {
    this.album$ = apiService.getAll('Albums');
    this.album$.subscribe(x => console.log(x))
  }

  ngOnInit(): void {
    this.images$ = this.getImages.getAll();
  }

}
