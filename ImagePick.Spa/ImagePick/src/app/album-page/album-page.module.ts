import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AlbumPageRoutingModule } from './album-page-routing.module';
import { AlbumPageComponent } from './album-page.component';
import { NavbarModule } from '../components/navbar/navbar.module';


@NgModule({
  declarations: [
    AlbumPageComponent
  ],
  imports: [
    CommonModule,
    AlbumPageRoutingModule,
    NavbarModule,
  ]
})
export class AlbumPageModule { }
