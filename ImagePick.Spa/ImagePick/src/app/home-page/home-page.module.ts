import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomePageRoutingModule } from './home-page-routing.module';
import { HomeComponent } from './home/home.component';
import { NavbarModule } from '../components/navbar/navbar.module';
import { ImageListModule } from '../components/image-list/image-list.module';


@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    HomePageRoutingModule,
    NavbarModule,
    ImageListModule,
  ]
})
export class HomePageModule { }
