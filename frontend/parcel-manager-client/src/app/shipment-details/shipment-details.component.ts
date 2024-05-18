import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { ShipmentService } from '../services/shipmentService/shipment.service';
import { Shipment, AirportCodes } from '../interfaces/shipments';
import { BagResultsListComponent } from '../bag-results-list/bag-results-list.component';
import { LetterBag, ParcelBag } from '../interfaces/bags';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-shipment-details',
  standalone: true,
  imports: [CommonModule, BagResultsListComponent, RouterLink],
  templateUrl: './shipment-details.component.html',
  styleUrl: './shipment-details.component.scss'
})
export class ShipmentDetailsComponent {

  route: ActivatedRoute = inject(ActivatedRoute);
  shipmentService = inject(ShipmentService);
  shipment: Shipment | undefined;
  errorMessage: string = '';
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
      },
      error: (error: any) => {
        console.error(error);
        this.errorMessage = 'Error retrieving shipment: ', error;
      }
    });
  }

  finaliseShipment() {
    if (this.shipment?.isFinalised) {
      window.alert(`Shipment ${this.shipment?.shipmentId} is already finalised.`);
      return
    }
    const result = window.confirm("Are you sure you want to finalise this shipment?");
    if (result) {
      console.log("YES")  
      this.shipmentService.finaliseShipment(this.shipment!.shipmentId).subscribe({
        next: () => {
          this.errorMessage = '';
          window.alert(`Shipment ${this.shipment?.shipmentId} finalised successfully.`);
          this.getShipmentById(this.shipment!.shipmentId);
        },
        error: (error: any) => {
          console.error('EROR FROM FINALISATION ', error);
          this.errorMessage = 'Could not finalise shipment: ' + error.toString();
          window.alert(this.errorMessage);
        }
      })
    }
  }
}
