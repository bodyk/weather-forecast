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
    this.history = this.historyService.getHistory();
    this.history.subscribe(data => console.log(data));
  }

  onClearHistory() {

  }

  formIconPath(iconName: string): string {
      return this.historyService.formIconPath(iconName);
    }

  showHide(buttonMoreLess, elementid: string) : void {
      if (document.getElementById(elementid).style.display === 'none') {
          document.getElementById(elementid).style.display = '';
          buttonMoreLess.value = 'less';
      } else {
          document.getElementById(elementid).style.display = 'none';
          buttonMoreLess.value = 'more...';
      }
  }

}
