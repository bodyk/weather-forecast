import { Injectable } from '@angular/core';
import { ApiBaseService } from './api-base.service';
import { Http, Response } from '@angular/http';


@Injectable()
export class WeatherService extends ApiBaseService {
  constructor(protected http: Http) {
      super(http);
    }

  getWeather(cityName: string, countDays: string) {
    return super.get(this.baseRequest + "/WeatherInfo/" + cityName + "/" + countDays);
  }
}
