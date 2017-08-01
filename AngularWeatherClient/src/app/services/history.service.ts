import { Injectable } from '@angular/core';
import { DayInfoEntity } from './../models/DayInfoEntity';
import { Http, Response } from '@angular/http';
import { Observable } from "rxjs/Observable";
import { ApiBaseService } from './api-base.service'


@Injectable()
export class HistoryService extends ApiBaseService {
  constructor(protected http: Http) {
    super(http);
    this.apiDetailedGetRequest = this.apiDetailedDeleteRequest = this.apiBaseRequest + "History/";
  }

  getHistory() {
    return this.get();
  }

  deleteHistory() {
    this.delete();
  }
}
