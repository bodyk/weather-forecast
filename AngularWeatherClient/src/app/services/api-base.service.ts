import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';

@Injectable()
export class ApiBaseService {
  protected apiBaseRequest: string = "http://localhost:3344/api/";
  protected apiDetailedGetRequest: string;
  protected apiDetailedDeleteRequest: string;  

  iconPath: string = "http://openweathermap.org/img/w/";
  iconExtension: string = ".png";    
  
  constructor(protected http: Http) { }

  protected get() {
    return this.http.get(this.apiDetailedGetRequest)
        .map(res => res.json());
  }

  protected delete() {
    this.http.delete(this.apiDetailedDeleteRequest).subscribe((res) => { console.log(res)});
  }

  formIconPath(iconName: string): string {
      return this.iconPath + iconName + ((iconName.indexOf(this.iconExtension) === -1) ? this.iconExtension : '') ;
  }
}
