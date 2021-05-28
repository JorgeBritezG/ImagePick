import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GoogleLoginProvider, SocialUser } from "angularx-social-login";
import { SocialAuthService } from "angularx-social-login";
import { Observable, Subscription } from 'rxjs';
import { AuthenticateService } from '../providers/authenticate.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit, OnDestroy {

  isLogging: boolean = false;


  subscription: Subscription = new Subscription;

  constructor(
    private router: Router,
    private authService: AuthenticateService,
    private socialLoginService: SocialAuthService) { }


  ngOnInit(): void {


    this.subscription = this.socialLoginService.authState.subscribe(data => {
      console.log(data);
      if (data) {
        this.router.navigate(['/']);
      }
    });
    
  }

  signInWithGoogle(): void {
    this.isLogging = true;
    this.socialLoginService.signIn(GoogleLoginProvider.PROVIDER_ID).then(googleUser => {
      console.log(googleUser);
      this.authService.googleLogin(googleUser)
        .subscribe((data) => {
          console.log(data);
          this.router.navigate(['/']);
          this.isLogging = false;
        });
    });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
