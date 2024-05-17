import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ValidatorFn, AbstractControl } from '@angular/forms';
import { AirportCodes } from '../interfaces/shipments';

@Component({
  selector: 'app-add-shipment-form',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './add-shipment-form.component.html',
  styleUrl: './add-shipment-form.component.scss'
})
export class AddShipmentFormComponent {

  airportCodes: string[] = [AirportCodes.TLL.toString(), AirportCodes.HEL.toString(), AirportCodes.RIX.toString()];
  todaysDate = new Date();
  addShipmentForm!: FormGroup;

  constructor() {
    this.addShipmentForm = new FormGroup({
      airport: new FormControl(this.airportCodes[0], [Validators.required, this.airportCodeValidator()]),
      destinationCountry: new FormControl('LV', [Validators.required, Validators.pattern("^(EE|LV|FI)$")]),
      flightNumber: new FormControl('LL1111', [Validators.required, Validators.pattern("^[A-Z]{2}\\d{4}$")]),
      flightDate: new FormControl(this.todaysDate, [Validators.required, this.datetimeValidator()]),
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

  // addShipmentForm = new FormGroup(
  //   {
  //     airport: new FormControl(AirportCodes.TLL, [Validators.required, this.airportCodeValidator()]),
  //     destinationCountry: new FormControl('LV', [Validators.required, Validators.pattern("^(EE|LV|FI)$")]),
  //     flightNumber: new FormControl('LL1111', [Validators.required, Validators.pattern("^[A-Z]{2}\d{4}$")]),
  //     flightDate: new FormControl(this.todaysDate, [Validators.required, this.datetimeValidator()]),
  //   }
  // )

  applyFormSubmit() {
    console.log(this.addShipmentForm.value);
  }

}
