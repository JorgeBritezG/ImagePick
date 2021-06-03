import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Image } from '../models/image';
import { ApiService } from '../providers/api.service';

@Component({
  selector: 'app-album-page',
  templateUrl: './album-page.component.html',
  styleUrls: ['./album-page.component.css']
})
export class AlbumPageComponent implements OnInit {

  images$: Observable<Image[]> | undefined;



  constructor(
    private apiService: ApiService,
    private activatedRoute: ActivatedRoute,
  ) { }

  ngOnInit(): void {

    this.activatedRoute.params.subscribe( params  => {
      if (params === undefined) return;
      
      this.images$ = this.apiService.getAll(`Images/album/${params.id}`)


    })

  }

}
