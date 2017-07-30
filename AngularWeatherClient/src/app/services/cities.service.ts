import { Injectable } from '@angular/core';
import { City } from './../models/City';
import { Http, Response } from '@angular/http';
import { Observable } from "rxjs/Observable";

@Injectable()
export class CitiesService {
  apiRequest: string = "http://localhost:3344/api/Cities/";

  constructor(private http: Http) { }

  getCities(): Observable<Response> {
    return this.http.get(this.apiRequest);
  }

  private deserialize<T>(json): T[] {
    debugger;
    let collection: T[] = [];
    json.map((item: T) => {
        collection.push(item);
    });
    return collection;
}
}
