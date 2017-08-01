import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions } from '@angular/http';

import 'rxjs/add/operator/toPromise';

@Injectable()
export class ApiBaseService {
  protected baseRequest: string = "http://localhost:3344/api/";
  

  iconPath: string = "http://openweathermap.org/img/w/";
  iconExtension: string = ".png";    
  
  constructor(protected http: Http) { }

  protected get(getRequest: string) {
    return this.http.get(getRequest)
        .map(res => res.json());
  }

  protected delete(deleteRequest: string) : Promise<any>  {
    return this.http.delete(deleteRequest).toPromise();
  }

  protected post(postRequest: string, content: any) : Promise<any> {
    return this.http.post(postRequest, content).toPromise();
  }

  formIconPath(iconName: string): string {
      return this.iconPath + iconName + ((iconName.indexOf(this.iconExtension) === -1) ? this.iconExtension : '') ;
  }
}
