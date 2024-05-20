// ***********************************************
// This example namespace declaration will help
// with Intellisense and code completion in your
// IDE or Text Editor.
// ***********************************************
// declare namespace Cypress {
//   interface Chainable<Subject = any> {
//     customCommand(param: any): typeof customCommand;
//   }
// }
//
// function customCommand(param: any): void {
//   console.warn(param);
// }
//
// NOTE: You can use it like so:
// Cypress.Commands.add('customCommand', customCommand);
//
// ***********************************************
// This example commands.js shows you how to
// create various custom commands and overwrite
// existing commands.
//
// For more comprehensive examples of custom
// commands please read more here:
// https://on.cypress.io/custom-commands
// ***********************************************
//
//
// -- This is a parent command --
// Cypress.Commands.add("login", (email, password) => { ... })
//
//
// -- This is a child command --
// Cypress.Commands.add("drag", { prevSubject: 'element'}, (subject, options) => { ... })
//
//
// -- This is a dual command --
// Cypress.Commands.add("dismiss", { prevSubject: 'optional'}, (subject, options) => { ... })
//
//
// -- This will overwrite an existing command --
// Cypress.Commands.overwrite("visit", (originalFn, url, options) => { ... })

// cypress/support/commands/shipment.cy.ts

Cypress.Commands.add('addNewShipment', () => {
  cy.intercept('POST', 'https://localhost:7022/Shipment').as('createShipment');

  cy.get('button').contains('Create shipment').click();
  cy.get('#airport').select('TLL');
  cy.get('#destinationCountry').select('FI');
  cy.get('#flightDate').type("2066-01-01");
  cy.get('#flightTime').type('12:00');

  cy.get('button').contains('Create shipment').click();

  cy.wait('@createShipment').then((interception) => {
    expect(interception.response!.statusCode).to.eq(201);
    const shipmentId = interception.response!.body.shipmentId;

    console.log('THIS IS THE SHIPMENT ID ', shipmentId);

    cy.visit('/')

    return cy.wrap(shipmentId);
  });
});

Cypress.Commands.add('addParcelBag', (shipmentId: string) => {
  let destinationCountry;

  cy.intercept('GET', 'https://localhost:7022/Shipment/*').as('getShipment');
  cy.intercept('PUT', 'https://localhost:7022/Shipment/*/add-parcel-bag').as('addParcelBag');

  cy.get('.info-container').contains(shipmentId).click();

  cy.wait('@getShipment').then((interception) => {
    if (interception.response) {
      expect(interception.response.statusCode).to.eq(200);
      destinationCountry = interception.response.body.destinationCountry;

      cy.get('.results-list > .button-container > button').contains('Add new bag').click();

      cy.get('#bagType').select('Parcel');
      cy.get('#destinationCountry').select(destinationCountry);
      cy.get('button').contains('Add bag to shipment').click();

      cy.wait('@addParcelBag').then((interception) => {
        if (interception.response) {
          expect(interception.response.statusCode).to.eq(200);
        } else {
          console.log('No response received');
        }
      })
    } else {
      console.log('No response received');
    }
  });


}
);

Cypress.Commands.add('addLetterBag', (shipmentId: string) => {
  let destinationCountry;

  cy.intercept('GET', 'https://localhost:7022/Shipment/*').as('getShipment');
  cy.intercept('PUT', 'https://localhost:7022/Shipment/*/add-letter-bag').as('addLetterBag');

  cy.get('.info-container').contains(shipmentId).click();

  cy.wait('@getShipment').then((interception) => {
    if (interception.response) {
      expect(interception.response.statusCode).to.eq(200);
      destinationCountry = interception.response.body.destinationCountry;

      cy.get('.results-list > .button-container > button').contains('Add new bag').click();

      cy.get('#bagType').select('Letter');
      cy.get('#destinationCountry').select(destinationCountry);
      cy.get('button').contains('Add bag to shipment').click();

      cy.wait('@addLetterBag').then((interception) => {
        if (interception.response) {
          expect(interception.response.statusCode).to.eq(200);
        } else {
          console.log('No response received');
        }
      })
    } else {
      console.log('No response received');
    }
  });

});

Cypress.Commands.add('addParcelToBag', (shipmentId: string) => {
  cy.intercept('GET', `https://localhost:7022/Shipment/${shipmentId}`).as('getShipment');
  cy.intercept('PUT', `https://localhost:7022/ParcelBag/*/add-parcel`).as('addParcel');
  cy.intercept('GET', `https://localhost:7002/ParcelBag/*`).as('getParcelBag');

  cy.get('.info-container').contains(shipmentId).click();

  cy.wait('@getShipment').then((interception) => {
    if (interception.response) {
      expect(interception.response.statusCode).to.eq(200);
      cy.get('a > :nth-child(2)').contains('Parcel').click();
      cy.get('.results-list > button').contains('Add parcels').click();

      cy.get('#recipientName').type("Jeffrey");
      cy.get('#destinationCountry').select('FI');
      cy.get('#weight').type('500');
      cy.get('#price').type('100');
      cy.get('button').contains('Add parcel to bag').click();

      cy.wait('@addParcel').then((interception) => {
        if (interception.response) {
          expect(interception.response.statusCode).to.eq(200);
        } else {
          console.log('No response received');
        }
      })
    } else {
      console.log('No response received');
    }
  });
});

Cypress.Commands.add('addLettersToBag', (shipmentId: string) => {
  cy.intercept('GET', `https://localhost:7022/Shipment/${shipmentId}`).as('getShipment');
  cy.intercept('PUT', `https://localhost:7022/LetterBag/*/add-letters`).as('addLetters');

  cy.get('.info-container').contains(shipmentId).click();

  cy.wait('@getShipment').then((interception) => {
    if (interception.response) {
      expect(interception.response.statusCode).to.eq(200);
      cy.get('a > :nth-child(2)').contains('Letter').click();
      cy.get('button').contains('Add letters').click();

      cy.get('#letterCount').type("10");
      cy.get('#weight').clear().type('10');
      cy.get('#price').clear().type('10');
      cy.get('button').contains('Add letters to bag').click();

      cy.wait('@addLetters').then((interception) => {
        if (interception.response) {
          expect(interception.response.statusCode).to.eq(200);
        } else {
          console.log('No response received');
        }
      })
    } else {
      console.log('No response received');
    }
  });
});

Cypress.Commands.add('finaliseShipment', (shipmentId: string) => {
  cy.intercept('PUT', `https://localhost:7022/Shipment/${shipmentId}/finalise-shipment`).as('finaliseShipment');
  cy.intercept('GET', `https://localhost:7022/Shipment/${shipmentId}`).as('getShipment');

  cy.get('.info-container').contains(shipmentId).click();

  cy.wait('@getShipment').then((interception) => {
    if (interception.response) {
      expect(interception.response.statusCode).to.eq(200);
      cy.get('button').contains('Finalise Shipment').click();

      cy.wait('@finaliseShipment').then((interception) => {
        if (interception.response) {
          expect(interception.response.statusCode).to.eq(200);
        } else {
          console.log('No response received');
        }
      })

 
    } else {
      console.log('No response received');
    }
  });
})


