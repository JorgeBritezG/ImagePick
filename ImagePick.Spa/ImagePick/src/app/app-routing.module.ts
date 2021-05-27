import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Home'
    },
    loadChildren: () => import('./home-page/home-page.module').then(m => m.HomePageModule)
    
  },
  {
    path: 'login',
    data: {
      title: 'Login'      
    },
    loadChildren: () => import('./login-page/login-page.module').then(m => m.LoginPageModule)
  },
  { path: '**', redirectTo: '' }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
