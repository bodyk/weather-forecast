import { Component, OnInit, Input } from '@angular/core';
import { WeatherService } from './../services/weather.service';
import { CitiesService } from './../services/cities.service';
import { Observable } from "rxjs/Observable";
import { City } from "../models/City";
import { WeatherEntity } from "../models/WeatherEntity";
import { DetailedWeatherInfo } from "../models/DetailedWeatherInfo";

@Component({
  selector: 'app-weather-info',
  providers: [WeatherService],
  templateUrl: './weather-info.component.html',
  styleUrls: ['./weather-info.component.css']
})
export class WeatherInfoComponent implements OnInit {

    cities: Observable<City[]>;
    @Input() curCity: string;
    @Input() countForecastDays: string;
    weatherInfo: Observable<DetailedWeatherInfo>;
    iconPath: string = "http://openweathermap.org/img/w/";
    iconExtension: string = ".png";    

    constructor(private weatherService: WeatherService, private citiesService: CitiesService) {
          this.cities = this.citiesService.getCities();
          this.countForecastDays = "1"; 
    }

    ngOnInit() {
    }

    onCityClick(cityName: string) {
      this.curCity = cityName;
    }

    onShowWeather() {
      if (this.curCity.length != 0)
      {
        this.weatherInfo = this.weatherService.getWeather(this.curCity, this.countForecastDays);
      }
    }

    formIconPath(iconName: string): string {
      return this.iconPath + iconName + this.iconExtension;
    }

}
