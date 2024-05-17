import { DestinationCountry } from "./destinationCountries";
import { Bag } from "./bags"; 

export enum AirportCodes {
  TLL = 0,
  HEL = 1,
  RIX = 2
}

export interface Shipment {

  shipmentId: string;
  airport: AirportCodes;
  airportCodeString: string;
  destinationCountry: DestinationCountry;
  flightNumber: string;
  flightDate: Date;
  bags: Bag[];
  isFinalised: boolean;

}