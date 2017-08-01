import { Injectable, OnInit } from '@angular/core';
import { City } from './../models/City';
import { Http, Response } from '@angular/http';
import { Observable } from "rxjs/Observable";
import { ApiBaseService } from './api-base.service';

@Injectable()
export class CitiesService extends ApiBaseService {
  
  constructor(protected http: Http) {
    super(http);
    this.baseRequest += "Cities/";  
  }

  getCities() {
    return this.get(this.baseRequest);
  }

  addCity(cityName: City) : Promise<any> {
    return this.post(this.baseRequest + cityName.name, cityName);
  }

  deleteCity(cityName: string) : Promise<any> {
    return this.delete(this.baseRequest + '/' + cityName);
  }
}
