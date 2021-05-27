import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { GetImagesService } from 'src/app/providers/get-images.service';

@Component({
  selector: 'app-image-list',
  templateUrl: './image-list.component.html',
  styleUrls: ['./image-list.component.css']
})
export class ImageListComponent implements OnInit {

  images$: Observable<any[]> | undefined;


  constructor(
    private getImages: GetImagesService,
  ) { }

  ngOnInit(): void {
    this.images$ = this.getImages.getAll();
  }

}
