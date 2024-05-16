import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Shipment } from '../interfaces/shipments';
import { ShipmentService } from '../services/shipmentService/shipment.service';


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {

  shipmentList: Shipment[] = [];

  private shipmentService: ShipmentService = inject(ShipmentService);

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
      }
    })

  }

}
