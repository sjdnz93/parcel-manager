import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Shipment, AirportCodes } from '../interfaces/shipments';
import { ShipmentService } from '../services/shipmentService/shipment.service';
import { ShipmentResultsComponent } from '../shipment-results/shipment-results.component';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterModule, CommonModule, ShipmentResultsComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {

  shipmentList: Shipment[] = [];

  errorMessagae: string = '';

  shipmentService: ShipmentService = inject(ShipmentService);

  AirportCodes: any = AirportCodes;

  ngOnInit() {
    this.getAllShipments();
  }

  getAllShipments() {
    this.shipmentService.getAllShipments().subscribe({
      next: (data) => {
        this.shipmentList = data;
        console.log('Shipments: ', data);
      },
      error: (error) => {
        console.log('Error retrieving shipments: ', error);
        this.errorMessagae = 'Error retrieving shipments: ', error;
      }
    })

  }

}
