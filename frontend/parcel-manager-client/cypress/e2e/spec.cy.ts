/// <reference types="cypress" />



describe('ParcelManager Tests', () => {

  beforeEach(() => {
    cy.visit('/');
    

  })

  it.only('Can create a new shipment, add parcel and letter bags, update bags with parcel/letter, finalise shipment', () => {

    cy.addNewShipment().then((shipmentId): void => {
      console.log('Shipment ID: ', shipmentId);
      cy.visit('/')
      cy.addParcelBag(shipmentId);
      cy.visit('/');
      //cy.get('.info-container').contains(shipmentId).click();
      cy.addLetterBag(shipmentId);
      cy.visit('/');
      cy.addParcelToBag(shipmentId);
      cy.visit('/');
      cy.addLettersToBag(shipmentId);
      cy.visit('/');
      cy.finaliseShipment(shipmentId);
      cy.visit('/');
    });


  });


})
