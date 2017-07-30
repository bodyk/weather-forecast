import { Component, OnInit } from '@angular/core';
import { CitiesService } from './../services/cities.service'

@Component({
  selector: 'app-cities',
  providers: [CitiesService],
  templateUrl: './cities.component.html',
  styleUrls: ['./cities.component.css']
})
export class CitiesComponent implements OnInit {

  constructor(private citiesService: CitiesService) { }

  ngOnInit() {
  }

}
