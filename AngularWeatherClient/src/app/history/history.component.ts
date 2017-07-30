import { Component, OnInit } from '@angular/core';
import { HistoryService } from './../services/history.service'

@Component({
  selector: 'app-history',
  providers: [HistoryService],
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {

  constructor(private historyService: HistoryService) { }

  ngOnInit() {
  }

}
