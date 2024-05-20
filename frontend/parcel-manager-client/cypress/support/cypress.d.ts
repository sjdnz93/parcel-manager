/// <reference types="cypress" />

import { Shipment } from '../../src/app/interfaces/shipments'; // Adjust the path as necessary

declare global {
  namespace Cypress {
    interface Chainable {
      addNewShipment(): Chainable<string>;
      addParcelBag(shipmentId: string): Chainable<void>;
      addLetterBag(shipmentId: string): Chainable<void>;
      addParcelToBag(shipmentId: string): Chainable<void>;
      addLettersToBag(shipmentId: string): Chainable<void>;
      finaliseShipment(shipmentId: string): Chainable<void>;
    }
  }
}
