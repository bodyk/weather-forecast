import { Injectable } from '@angular/core';
import { DayInfoEntity } from './../models/DayInfoEntity';
import { Http, Response } from '@angular/http';
import { Observable } from "rxjs/Observable";
import { ApiBaseService } from './api-base.service'


@Injectable()
export class HistoryService extends ApiBaseService {
  constructor(protected http: Http) {
    super(http);
    this.baseRequest += "History/";
  }

  getHistory() {
    return this.get(this.baseRequest);
  }

  deleteHistory() : Promise<any> {
    return this.delete(this.baseRequest);
  }
}
