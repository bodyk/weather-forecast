import { DayInfoEntity } from './DayInfoEntity';
import { Observable } from "rxjs/Observable";

export interface WeatherEntity {
        dayInfoEntities: Observable<DayInfoEntity[]>;
        id: number;
        cityName: string;
        countryCode: string;
        countForecastDays: number;
    }