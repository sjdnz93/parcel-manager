import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Shipment, AirportCodes } from '../interfaces/shipments';
import { ShipmentService } from '../services/shipmentService/shipment.service';
import { ShipmentResultsComponent } from '../shipment-results/shipment-results.component';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ValidatorFn, AbstractControl } from '@angular/forms';



@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterModule, CommonModule, ShipmentResultsComponent, ReactiveFormsModule],
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

  // airportCodeValidator(): ValidatorFn {
  //   return (control: AbstractControl): { [key: string]: any } | null => {
  //     const validCodes = [AirportCodes.TLL, AirportCodes.RIX, AirportCodes.HEL];
  //     if (control.value && !validCodes.includes(control.value)) {
  //       return { 'invalidAirportCode': { value: control.value } };
  //     }
  //     return null;
  //   };
  // }

  // datetimeValidator(): ValidatorFn {
  //   return (control: AbstractControl): { [key: string]: any } | null => {
  //     const inputDate = new Date(control.value);
  //     if (isNaN(inputDate.getTime())) {
  //       return { 'invalidDateTime': true };
  //     }
  //     return null;
  //   };
  // }

  // addShipmentForm = new FormGroup(
  //   {
  //     airport: new FormControl(0, [Validators.required, this.airportCodeValidator()]),
  //     destinationCountry: new FormControl('LV', [Validators.required, Validators.pattern("^(EE|LV|FI)$")]),
  //     flightNumber: new FormControl('', [Validators.required, Validators.pattern("^[A-Z]{2}\d{4}$")]),
  //     flightDate: new FormControl('', [Validators.required, this.datetimeValidator()]),
  //   }
  // )

}
