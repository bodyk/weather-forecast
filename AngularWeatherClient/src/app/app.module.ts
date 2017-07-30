import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import 'hammerjs';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MdInputModule, MdButtonModule} from '@angular/material';
import { FormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { WeatherInfoComponent } from './weather-info/weather-info.component';
import { HistoryComponent } from './history/history.component';
import { CitiesComponent } from './cities/cities.component';
import { HistoryService} from './services/history.service';
import { CitiesService} from './services/cities.service';
import { WeatherService} from './services/weather.service';


@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    WeatherInfoComponent,
    HistoryComponent,
    CitiesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    MdInputModule,
    MdButtonModule
  ],
  providers: [HistoryService, CitiesService, WeatherService],
  bootstrap: [AppComponent]
})
export class AppModule { }
