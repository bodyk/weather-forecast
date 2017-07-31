import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';

@Injectable()
export class ApiBaseService {
  protected apiBaseRequest: string = "http://localhost:3344/api/";
  protected apiDetailedGetRequest: string;

  iconPath: string = "http://openweathermap.org/img/w/";
  iconExtension: string = ".png";    
  
  constructor(protected http: Http) { }

  protected get() {
    return this.http.get(this.apiDetailedGetRequest)
        .map(res => res.json());
  }

  formIconPath(iconName: string): string {
      return this.iconPath + iconName + this.iconExtension;
  }
}
