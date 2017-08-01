import { Component, OnInit } from '@angular/core';
import { HistoryService } from './../services/history.service'
import { Observable } from "rxjs/Observable";
import { DayInfoEntity } from './../models/DayInfoEntity';
import { WeatherEntity } from "../models/WeatherEntity";
import { HistoryEntry } from "../models/HistoryEntry";

@Component({
  selector: 'app-history',
  providers: [HistoryService],
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {
  history: Observable<HistoryEntry[]>;

  constructor(private historyService: HistoryService) { }

  ngOnInit() {
    this.updateHistory();
  }

  updateHistory() {
    this.history = this.historyService.getHistory();
  }

  onClearHistory() {
    this.historyService.deleteHistory().then(() => this.updateHistory());
  }

  showHide(buttonMoreLess, elementid: string) : void {
      if (document.getElementById(elementid).style.display === 'none') {
          document.getElementById(elementid).style.display = '';
      } else {
          document.getElementById(elementid).style.display = 'none';
      }
  }

}
