import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ImageListComponent } from './image-list.component';
import { LikeButtonModule } from '../like-button/like-button.module';
import { AddAlbumButtonModule } from '../add-album-button/add-album-button.module';



@NgModule({
  declarations: [
    ImageListComponent
  ],
  imports: [
    CommonModule,
    LikeButtonModule,
    AddAlbumButtonModule,
  ],
  exports: [
    ImageListComponent
  ]
})
export class ImageListModule { }
