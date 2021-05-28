import { Component, OnInit } from '@angular/core';
import { GoogleLoginProvider } from "angularx-social-login";
import { SocialAuthService } from "angularx-social-login";
import { AuthenticateService } from '../providers/authenticate.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  isLogging: boolean = false;

  constructor(private authService: AuthenticateService,
    private socialLoginService: SocialAuthService) { }


  ngOnInit(): void {
  }

  signInWithGoogle(): void {
    this.isLogging = true;
    this.socialLoginService.signIn(GoogleLoginProvider.PROVIDER_ID).then(googleUser => {
      this.authService.googleLogin(googleUser)
        .subscribe((data) => {
          console.log(data);
          this.isLogging = false;
        });
    });
  }

}
