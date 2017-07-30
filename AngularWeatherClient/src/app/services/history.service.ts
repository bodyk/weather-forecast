import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { DayInfoEntity } from './../models/DayInfoEntity';
import { Http, Response } from '@angular/http';
import { Observable } from "rxjs/Observable";


@Injectable()
export class HistoryService {
  apiRequest: string = "http://localhost:3344/api/History/";
  constructor(private http: Http) { }

  getHistory(): Observable<Response> {
    return this.http.get(this.apiRequest);
  }
}
