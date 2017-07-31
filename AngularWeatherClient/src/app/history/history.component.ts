import { Component, OnInit } from '@angular/core';
import { HistoryService } from './../services/history.service'
import { Observable } from "rxjs/Observable";
import { DayInfoEntity } from './../models/DayInfoEntity';
import { WeatherEntity } from "../models/WeatherEntity";
import { DetailedWeatherInfo } from "../models/DetailedWeatherInfo";

@Component({
  selector: 'app-history',
  providers: [HistoryService],
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {
  history: Observable<DetailedWeatherInfo[]>;

  constructor(private historyService: HistoryService) { }

  ngOnInit() {
    this.history = this.historyService.getHistory();
  }

}
