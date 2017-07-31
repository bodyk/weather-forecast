import { Injectable } from '@angular/core';
import { City } from './../models/City';
import { Http, Response } from '@angular/http';
import { Observable } from "rxjs/Observable";
import { ApiBaseService } from './api-base.service';

@Injectable()
export class CitiesService extends ApiBaseService {
  constructor(protected http: Http) {
    super(http);
    this.apiDetailedGetRequest = this.apiBaseRequest + "Cities/";
  }

  getCities() {
    return this.get();
  }
}
