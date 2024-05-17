import { DestinationCountry } from "./destinationCountries";

export interface Parcel {
  parcelId: string;
  recipientName: string;
  destinationCountry: DestinationCountry;
  weight: number;
  price: number;
}

export interface ParcelFormSubmit {
  recipientName: string;
  destinationCountry: DestinationCountry;
  weight: number;
  price: number;
}