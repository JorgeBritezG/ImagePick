import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { JwtService } from '../providers/jwt.service';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(private jwtService: JwtService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token = this.jwtService.getToken();
    const imageRequest = request.headers.get('Authorization');
    if (!imageRequest) {
      if (token) {
        request = request.clone({
          setHeaders: {
            'Authorization': `Bearer ${token}`
          }
        });
      }
    }
    return next.handle(request);
  }
}
