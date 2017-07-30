import { Coord } from './Coord';

export interface City {
    id: number;
    name: string;
    coord?: Coord;
    country?: any;
    population: number;
}