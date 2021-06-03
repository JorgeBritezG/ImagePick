import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlbumPageComponent } from './album-page.component';

const routes: Routes = [
  {
    path: ':id',
    component: AlbumPageComponent,
    data: {
      title: 'AlbumPage'
    }

  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AlbumPageRoutingModule { }
