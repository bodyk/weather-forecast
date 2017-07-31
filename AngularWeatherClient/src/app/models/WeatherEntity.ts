import { DayInfoEntity } from './DayInfoEntity';
import { Observable } from "rxjs/Observable";

export interface WeatherEntity {
        dayInfoEntities: DayInfoEntity[];
        id: number;
        cityName: string;
        countryCode: string;
        countForecastDays: number;
    }