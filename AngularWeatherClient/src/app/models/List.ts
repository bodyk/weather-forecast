import { Temperture } from './Temperature';
import { Weather } from './Weather';


export interface List {
        dt: number;
        temp: Temperture;
        pressure: number;
        humidity: number;
        weather: Weather[];
        speed: number;
        deg: number;
        clouds: number;
        rain?: any;
}