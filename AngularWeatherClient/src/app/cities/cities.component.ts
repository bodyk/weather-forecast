import { Component, OnInit, Input } from '@angular/core';
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
  @Input() curCity: string;

  constructor(private citiesService: CitiesService, private http: Http) { }

  ngOnInit() {
    this.updateCities();
  }

  updateCities() { 
    this.cities = this.citiesService.getCities();
  }

  onDeleteCity(cityName: string) : void {
    this.citiesService.deleteCity(cityName).then(() => this.updateCities());
  }
  
  onAddCity() : void {
    if (this.curCity.length != 0)
    {
      let city: City = {
        name: this.curCity,
        coord: null,
        country: "",
        id: 0,
        population: 0
      };
      this.citiesService.addCity(city).then(() => this.updateCities());
    }
  }
}
