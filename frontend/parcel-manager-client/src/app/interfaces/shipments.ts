import { DestinationCountry } from "./destinationCountries";
import { Bag } from "./bags"; 

enum AirportCodes {
  TLL,
  HEL,
  RIX
}

export interface Shipment {

  shipmentId: string;
  airport: AirportCodes;
  destinationCountry: DestinationCountry;
  flightNumber: string;
  flightDate: Date;
  bags: Bag[];
  isFinalised: boolean;

}