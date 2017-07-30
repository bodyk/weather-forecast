import { Component, OnInit } from '@angular/core';
import { WeatherService } from './../services/weather.service'

@Component({
  selector: 'app-weather-info',
  providers: [WeatherService],
  templateUrl: './weather-info.component.html',
  styleUrls: ['./weather-info.component.css']
})
export class WeatherInfoComponent implements OnInit {



  constructor(private weatherService: WeatherService) {

  }

  ngOnInit() {
  }

}
