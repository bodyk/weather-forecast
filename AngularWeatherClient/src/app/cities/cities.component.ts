import { Component, OnInit } from '@angular/core';
import { CitiesService } from './../services/cities.service';
import { City } from './../models/City';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from "rxjs/Observable";

@Component({
  selector: 'app-cities',
  providers: [CitiesService],
  templateUrl: './cities.component.html',
  styleUrls: ['./cities.component.css']
})
export class CitiesComponent implements OnInit {
  cities: Observable<City[]>;

  constructor(private citiesService: CitiesService, private http: Http) { }

  ngOnInit() {
    this.citiesService.getCities()
    .map(res => res.json())
    .subscribe(cities => {
      this.cities = cities;
      console.log(cities);
    });
      console.log(this.cities);
      debugger;
  }
}
