import { City } from './City';
import { List } from './List';


export interface RootObject {
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