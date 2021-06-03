import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AlbumPageRoutingModule } from './album-page-routing.module';
import { AlbumPageComponent } from './album-page.component';


@NgModule({
  declarations: [
    AlbumPageComponent
  ],
  imports: [
    CommonModule,
    AlbumPageRoutingModule
  ]
})
export class AlbumPageModule { }
