import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Shipment, AirportCodes } from '../interfaces/shipments';



@Component({
  selector: 'app-shipment-results',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './shipment-results.component.html',
  styleUrl: './shipment-results.component.scss'
})
export class ShipmentResultsComponent {
  @Input() shipment!: Shipment;
  @Input() AirportCodes: any = AirportCodes;
}
