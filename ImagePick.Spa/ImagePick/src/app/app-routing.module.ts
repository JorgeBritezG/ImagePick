import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  // {
  //   path: '',
  //   redirectTo: 'home',
  //   pathMatch: 'full',    
  // },
  {
    path: '',
    data: {
      title: 'Home'
    },
    loadChildren: () => import('./home-page/home-page.module').then(m => m.HomePageModule)
    
  },
  { path: '**', redirectTo: '' }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
