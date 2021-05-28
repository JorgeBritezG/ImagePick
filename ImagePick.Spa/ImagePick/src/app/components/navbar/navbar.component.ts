import { Component, OnDestroy, OnInit } from '@angular/core';
import { SocialAuthService, SocialUser } from 'angularx-social-login';
import { Observable, Subscription } from 'rxjs';
import { AuthenticateService } from 'src/app/providers/authenticate.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit, OnDestroy {
  
  logged = false;
  model: SocialUser | null | undefined;
  subscription: Subscription = new Subscription;
  authState$: Observable<SocialUser> | undefined;
  
  constructor(
    private socialAuthService: SocialAuthService,
    private authService: AuthenticateService

    ) { }

  ngOnInit(): void {
    this.authState$ = this.socialAuthService.authState;
    this.subscription = this.socialAuthService.authState.subscribe(data => {
      console.log(data);
      if (data) {
        this.model = data;
        this.logged = true;
      }
      else {
        this.model = null;
        this.logged = false;
      }
    });

  }
  
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  logout() {
    this.authService.logout();
  }

}
