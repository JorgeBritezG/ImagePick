import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Like } from '../models/like';

@Injectable({
  providedIn: 'root'
})
export class LikedService {

  private likedSubject = new BehaviorSubject<Like>({
    imageId: "",
    like: false,
  });
  
  public liked$ = this.likedSubject.asObservable();


  constructor() { }

  like(imageId: string) {
    this.likedSubject.next({
      imageId,
      like: true, 
    });
  }

  unLike(imageId: string) {
    this.likedSubject.next({
      imageId,
      like: false,
    });
  }

}
