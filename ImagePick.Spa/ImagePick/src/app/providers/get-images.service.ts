import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GetImagesService {

  private imagesUrl = 'https://api.unsplash.com/photos/'
  private clientId: string = 'Client-ID GBNNOogp1Wdif58jdhXJZkzr0dF0ZlhaF36Kvd-c-SA'

  constructor(
    private http: HttpClient,
  ) { }

  getAll(): Observable<any[]> {
    
    let header = new HttpHeaders();

    return this.http.get<any[]>(this.imagesUrl, {
      headers: header.set('Authorization', this.clientId)
    })
  }
}
