import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { GoogleUserRequest } from '../models/google-user';
import { UserToken } from '../models/user-token';
import { JwtService } from './jwt.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticateService {

  private baseUrl = environment.baseUrl;
  
  private currentUserSubject = new BehaviorSubject<UserToken | null>({} as UserToken);
  public currentUser = this.currentUserSubject.asObservable();

  constructor(private httpClient: HttpClient, private jwtService: JwtService, private router: Router) {
    this.currentUserSubject = new BehaviorSubject<UserToken | null>(this.jwtService.getUser());
    this.currentUser = this.currentUserSubject.asObservable();
  }

  googleLogin(googleUser: GoogleUserRequest): Observable<UserToken | null> {
    return this.httpClient
      .post<UserToken>(`${this.baseUrl}/Auth/googleauthenticate`, googleUser)
      .pipe(
        map((profile : UserToken)  => {
        this.setAuth(profile);
        return profile;
      }))
  }

  setAuth(user: UserToken) {
    this.jwtService.saveUser(user);
    this.currentUserSubject.next(user);
  }

  logout() {
    this.purgeAuth();
  }

  purgeAuth() {
    this.jwtService.destroyUser();
    this.currentUserSubject.next(null);
  }
}
