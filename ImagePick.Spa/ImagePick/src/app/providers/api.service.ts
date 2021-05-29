import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private apiUrl = environment.baseUrl

  constructor(
    private http: HttpClient,
  ) { }

  getAll(controller: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/${controller}`);
  }

  getById(controller: string, id: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/${controller}/${id}`);
  }

  create(model: any, controller: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/${controller}`, model);
  }

  update(model: any, controller: string): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${controller}`, model);
  }

  delete(controller: string, id: string): Observable<any[]> {
    return this.http.delete<any[]>(`${this.apiUrl}/${controller}/${id}`);
  }

}
