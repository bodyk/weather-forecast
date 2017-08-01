import { WeatherEntity } from "./WeatherEntity";

export interface HistoryEntry {
        weatherEntity: WeatherEntity;
        id: number;
        requestTime: Date;
        weatherEntity_Id: number;
}