import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ValidatorFn, AbstractControl } from '@angular/forms';
import { AirportCodes, ShipmentForm } from '../interfaces/shipments';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ShipmentService } from '../services/shipmentService/shipment.service';



@Component({
  selector: 'app-add-shipment-form',
  standalone: true,
  imports: [ReactiveFormsModule, FormsModule, CommonModule],
  templateUrl: './add-shipment-form.component.html',
  styleUrl: './add-shipment-form.component.scss'
})
export class AddShipmentFormComponent {

  airportCodes: string[] = [AirportCodes.TLL.toString(), AirportCodes.HEL.toString(), AirportCodes.RIX.toString()];

  addShipmentForm!: FormGroup;
  flightNumber!: string;

  todaysDate = new Date();
  hours = this.todaysDate.getHours();
  minutes = this.todaysDate.getMinutes();
  time = this.hours + ':' + this.minutes;
  shipmentService: ShipmentService = inject(ShipmentService);
  errorMessage: string | undefined;


  constructor() {
    this.addShipmentForm = new FormGroup({
      airport: new FormControl(this.airportCodes[0], [Validators.required, this.airportCodeValidator()]),
      destinationCountry: new FormControl('LV', [Validators.required, Validators.pattern("^(EE|LV|FI)$")]),
      flightNumber: new FormControl('LL1111', [Validators.required, Validators.pattern("^[A-Z]{2}\\d{4}$")]),
      flightDate: new FormControl(this.todaysDate, [Validators.required, this.datetimeValidator()]),
      flightTime: new FormControl(this.time, [Validators.required])
    });
  }

  airportCodeValidator(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
      const validCodes = [AirportCodes.TLL.toString(), AirportCodes.RIX.toString(), AirportCodes.HEL.toString()];
      if (control.value && !validCodes.includes(control.value)) {
        return { 'invalidAirportCode': { value: control.value } };
      }
      return null;
    };
  }

  datetimeValidator(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
      const inputDate = new Date(control.value);
      if (isNaN(inputDate.getTime())) {
        return { 'invalidDateTime': true };
      }
      return null;
    };
  }

  shipmentFormSubmit() {
    const date = new Date(this.addShipmentForm.value.flightDate);
    const time = this.addShipmentForm.value.flightTime;
    const [hours, minutes] = time.split(':');
    date.setHours(hours);
    date.setMinutes(minutes);

    const request: ShipmentForm = {
      airport: Number(this.addShipmentForm.value.airport),
      destinationCountry: this.addShipmentForm.value.destinationCountry,
      flightNumber: this.addShipmentForm.value.flightNumber,
      flightDate: date
    }

    console.log('REQUEST: ', request);
    //window.alert("Are you sure you want to create this shipment?");
    this.shipmentService.createShipment(request).subscribe({
      next: (response) => {
        console.log('Shipment created: ', response);
        this.errorMessage = '';
        window.alert(`Shipment ${response.shipmentId} created successfully.`);
      },
      error: (error) => {
        console.log(error);
        this.errorMessage = error;
      }
    });
  }

}
