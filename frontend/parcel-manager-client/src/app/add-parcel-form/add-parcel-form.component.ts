import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ParcelBagService } from '../services/bagService/parcel-bag.service';
import { RouterLink } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { ParcelFormSubmit } from '../interfaces/parcels';

@Component({
  selector: 'app-add-parcel-form',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, RouterLink],
  templateUrl: './add-parcel-form.component.html',
  styleUrl: './add-parcel-form.component.scss'
})
export class AddParcelFormComponent {

  errorMessage: string | undefined;
  route: ActivatedRoute = inject(ActivatedRoute);
  shipmentId!: string;
  bagId!: string;
  addParcelForm!: FormGroup;
  parcelBagService = inject(ParcelBagService);


  ngOnInit() {
    this.shipmentId = this.route.snapshot.params['shipmentId'];
    this.bagId = this.route.snapshot.params['bagId'];

    this.addParcelForm = new FormGroup({
      recipientName: new FormControl('', [Validators.required]),
      destinationCountry: new FormControl('EE', [Validators.required, Validators.pattern("^(EE|LV|FI)$")]),
      weight: new FormControl(0, [Validators.required, Validators.min(0.1)]),
      price: new FormControl(0, [Validators.required, Validators.min(0.1)]),
    });
  }

  parcelFormSubmit() {
    console.log(this.addParcelForm.value);

    const request: ParcelFormSubmit = {
      recipientName: this.addParcelForm.value.recipientName,
      destinationCountry: this.addParcelForm.value.destinationCountry,
      weight: this.addParcelForm.value.weight,
      price: this.addParcelForm.value.price
    };

    this.parcelBagService.addParcelToBag(this.bagId, request).subscribe({
      next: () => {
        this.errorMessage = '';
        window.alert('Parcel added successfully to bag.');
      },
      error: (error) => {
        console.log('ERRORFROM FORM', error);
        this.errorMessage = error;
      }
    });
    
  }

}