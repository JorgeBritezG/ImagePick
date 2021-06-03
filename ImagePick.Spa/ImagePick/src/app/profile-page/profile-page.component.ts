import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SocialAuthService, SocialUser } from 'angularx-social-login';
import { Observable, Subscription } from 'rxjs';
import { Album } from '../models/album';
import { ApiService } from '../providers/api.service';
import { AuthenticateService } from '../providers/authenticate.service';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.css']
})
export class ProfilePageComponent implements OnInit {

  albums$: Observable<Album[]> | undefined;  
  model: SocialUser | null | undefined;
  subscription: Subscription = new Subscription;

  constructor(    
    private socialAuthService: SocialAuthService,
    private authService: AuthenticateService,
    private router: Router,
    private apiService: ApiService,
  ) { }

  ngOnInit(): void {
  this.subscription = this.socialAuthService.authState.subscribe(data => {
    console.log(data);
    if (data) {
      this.model = data;
      this.albums$ = this.apiService.getAll(`Albums/by-user/${data?.id}`)

      this.albums$.subscribe(x => console.log(x));
    }
    else {
      this.model = null;
    }
  });


}

getSmallImage(album: Album) : string {
  console.log('Album', album);
  if (!album) return '';
  
  if(album.images?.length === 0) return '';

  if(!album.images) return ''

  return album?.images[0]?.smallUrl ?? '';
}

ngOnDestroy() {
  this.subscription.unsubscribe();
}

logout() {
  this.authService.logout();
  this.router.navigate(['/']);
}
}
