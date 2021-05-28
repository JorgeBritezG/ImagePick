import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SocialAuthService, SocialUser } from 'angularx-social-login';
import { Subscription } from 'rxjs';
import { AuthenticateService } from '../providers/authenticate.service';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.css']
})
export class ProfilePageComponent implements OnInit {

  
  model: SocialUser | null | undefined;
  subscription: Subscription = new Subscription;

  constructor(    
    private socialAuthService: SocialAuthService,
    private authService: AuthenticateService,
    private router: Router,
  ) { }

  ngOnInit(): void {
  this.subscription = this.socialAuthService.authState.subscribe(data => {
    console.log(data);
    if (data) {
      this.model = data;
    }
    else {
      this.model = null;
    }
  });

}

ngOnDestroy() {
  this.subscription.unsubscribe();
}

logout() {
  this.authService.logout();
  this.router.navigate(['/']);
}
}
