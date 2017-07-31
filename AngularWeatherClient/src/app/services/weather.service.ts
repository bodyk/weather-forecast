import { Injectable } from '@angular/core';
import { ApiBaseService } from './api-base.service';
import { Http, Response } from '@angular/http';


@Injectable()
export class WeatherService extends ApiBaseService {
  constructor(protected http: Http) {
      super(http);
    }

  getWeather(cityName: string, countDays: string) {
    this.apiDetailedGetRequest = this.apiBaseRequest +"/WeatherInfo/" + cityName + "/" + countDays;    
    return super.get();
  }
}
