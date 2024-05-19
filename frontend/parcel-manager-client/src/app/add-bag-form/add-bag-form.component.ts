import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ShipmentService } from '../services/shipmentService/shipment.service';
import { RouterLink } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { BagFormSubmit } from '../interfaces/bags';

@Component({
  selector: 'app-add-bag-form',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, RouterLink],
  templateUrl: './add-bag-form.component.html',
  styleUrl: './add-bag-form.component.scss'
})
export class AddBagFormComponent {

  shipmentService: ShipmentService = inject(ShipmentService);
  errorMessage: string | undefined;
  addBagForm!: FormGroup;
  shipmentId!: string;
  route: ActivatedRoute = inject(ActivatedRoute);

  
ngOnInit(){
  this.addBagForm = new FormGroup({
    bagType: new FormControl('Letter', [Validators.required]),
    destinationCountry: new FormControl('LV', [Validators.required, Validators.pattern("^(EE|LV|FI)$")]),
  });
  this.shipmentId = this.route.snapshot.params['shipmentId'];;
}


  bagFormSubmit() {
    const bagType = this.addBagForm.value.bagType;
    const request: BagFormSubmit = {
      destinationCountry: this.addBagForm.value.destinationCountry
    };


    if (bagType == "Letter") {
      this.shipmentService.addLetterBagToShipment(this.shipmentId, request).subscribe({
        next: () => {
          this.errorMessage = '';
          window.alert(`Bag added successfully to shipment.`);
        },
        error: (error) => {
          console.log(error);
          this.errorMessage = error;
        }
      });;
    }
    else if (bagType == "Parcel") {
      this.shipmentService.addParcelBagToShipment(this.shipmentId, request).subscribe({
        next: () => {
          console.log('Bag added ');
          this.errorMessage = '';
          window.alert(`Bag added successfully to shipment.`);
        },
        error: (error) => {
          console.log(error);
          this.errorMessage = error;
        }
      });
    }
  }

}
