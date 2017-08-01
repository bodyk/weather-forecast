import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HistoryComponent } from "./history/history.component";
import { WeatherInfoComponent } from "./weather-info/weather-info.component";
import { CitiesComponent } from "./cities/cities.component";

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: '/weather'
  },
  {
    path: 'history',
    component: HistoryComponent
  }, {
    path: 'weather',
    component: WeatherInfoComponent
  }, {
    path: 'cities',
    component: CitiesComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
