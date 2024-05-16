import { DestinationCountry } from "./destinationCountries"
import { Parcel } from "./parcels"

type BagTypes = "Parcel" | "Letter"

export interface Bag {
  bagId: string
  bagType: BagTypes
  isFinalised: boolean
  destinationCountry: DestinationCountry
}

export interface ParcelBag extends Bag {
  parcels: Parcel[]
}

export interface LetterBag extends Bag {
  letterCount: number,
  weight: number,
  price: number
}