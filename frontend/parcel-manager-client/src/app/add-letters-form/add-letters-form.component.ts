import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { LetterBagService } from '../services/bagService/letter-bag.service';
import { LetterBagForm } from '../interfaces/bags';

@Component({
  selector: 'app-add-letters-form',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, RouterLink],
  templateUrl: './add-letters-form.component.html',
  styleUrl: './add-letters-form.component.scss'
})
export class AddLettersFormComponent {

  errorMessage: string | undefined;
  route: ActivatedRoute = inject(ActivatedRoute);
  shipmentId!: string;
  bagId!: string;
  addLettersForm!: FormGroup;
  letterBagService = inject(LetterBagService);


  constructor() {
    this.shipmentId = this.route.snapshot.params['shipmentId'];
    this.bagId = this.route.snapshot.params['bagId'];

    this.addLettersForm = new FormGroup({
      letterCount: new FormControl(1, [Validators.required, Validators.min(1)]),
      weight: new FormControl(0.1, [Validators.required, Validators.min(0.1)]),
      price: new FormControl(0.1, [Validators.required, Validators.min(0.1)]),
    });
  }

  lettersFormSubmit() {

    const request: LetterBagForm = {
      id: this.bagId,
      letterCount: this.addLettersForm.value.letterCount,
      weight: this.addLettersForm.value.weight,
      price: this.addLettersForm.value.price
    };

    console.log(request);

    this.letterBagService.addLettersToBag(this.bagId, request).subscribe({
      next: () => {
        this.errorMessage = '';
        window.alert('Letters added successfully to bag.');
      },
      error: (error) => {
        console.log('ERRORFROM FORM', error);
        this.errorMessage = error;
      }
    });

  }

}
