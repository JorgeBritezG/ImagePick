import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LikeButtonComponent } from './like-button.component';
import { AddAlbumButtonComponent } from '../add-album-button/add-album-button.component';



@NgModule({
  declarations: [
    LikeButtonComponent,
    AddAlbumButtonComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    LikeButtonComponent,
    AddAlbumButtonComponent
  ]
})
export class LikeButtonModule { }
