import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { ShipmentService } from '../services/shipmentService/shipment.service';
import { Shipment, AirportCodes } from '../interfaces/shipments';
import { BagResultsListComponent } from '../bag-results-list/bag-results-list.component';
import { LetterBag, ParcelBag } from '../interfaces/bags';



@Component({
  selector: 'app-shipment-details',
  standalone: true,
  imports: [CommonModule, BagResultsListComponent],
  templateUrl: './shipment-details.component.html',
  styleUrl: './shipment-details.component.scss'
})
export class ShipmentDetailsComponent {

  route: ActivatedRoute = inject(ActivatedRoute);
  shipmentService = inject(ShipmentService);
  shipment: Shipment | undefined;
  errorMessagae: string = '';
  AirportCodes: any = AirportCodes;

  bagIds: string[] = [];

  bags: (LetterBag | ParcelBag)[] = []


  ngOnInit() {
    const id = this.route.snapshot.params['id'];
    this.getShipmentById(id);
  }

  getShipmentById(id: string): void {
    this.shipmentService.getShipmentById(id).subscribe({
      next: (data) => {
        this.shipment = data;
        console.log('Shipment: ', data);
        this.getBagIds(this.shipment);
        console.log('Bag IDs: ', this.bagIds);

      },
      error: (error) => {
        console.error(error);
        this.errorMessagae = 'Error retrieving shipment: ', error;
      }
    });
  }

  getBagIds(shipment: Shipment): void {
    if (shipment) {

      for (let i = 0; i < shipment.bags.length; i++) {

        this.bagIds.push(shipment.bags[i].bagId);
      }
    }

  }

  // TODO: Maybe make a get each individual bag function call






}
