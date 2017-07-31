import { City } from './City';
import { List } from './List';


export interface DetailedWeatherInfo {
        city: City;
        cod: string;
        message: number;
        cnt: number;
        list: List[];
        id: number;
        cityName: string;
        countryCode: string;
        countForecastDays: number;
}