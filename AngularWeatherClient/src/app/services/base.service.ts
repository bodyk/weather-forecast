import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { City } from './../models/City';

@Injectable()
export class BaseService {
  defaultCities: City[];

  constructor(protected http: Http) { }

  protected getResponse<T>(request: string) : void {
    debugger;
    this.http.get(request)
    .subscribe(data => {
      this.defaultCities = data.json();
    });
  } 
}
