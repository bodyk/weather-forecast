import { Coord } from './Coord';

export class City {
    id: number;
    name: string;
    coord?: Coord;
    country?: any;
    population: number;
}