import { DestinationCountry } from "./destinationCountries"
import { Parcel } from "./parcels"

type BagTypes = "Parcel" | "Letter"

export interface Bag {
  bagId: string
  bagType: BagTypes
  isFinalised: boolean
  destinationCountry: DestinationCountry
  itemCount: number
  price: number
}

export interface ParcelBag extends Bag {
  parcels: Parcel[]
  weight: number
}

export interface LetterBag extends Bag {
  letterCount: number,
  weight: number,
}

export interface BagFormSubmit {
  destinationCountry: DestinationCountry
}

export interface LetterBagForm {
  id: string,
  letterCount: number,
  weight: number,
  price: number
}