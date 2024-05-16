import { DestinationCountry } from "./destinationCountries";

export interface Parcel {
  parcelId: string;
  recipientName: string;
  destinationCountry: DestinationCountry;
  weight: number;
  price: number;
}