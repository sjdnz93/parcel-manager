import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { LetterBag, ParcelBag, Bag } from '../interfaces/bags';
import { LetterBagService } from '../services/bagService/letter-bag.service';
import { ParcelBagService } from '../services/bagService/parcel-bag.service';
import { RouterLink } from '@angular/router';
import { ParcelResultsListComponent } from '../parcel-results-list/parcel-results-list.component';

@Component({
  selector: 'app-bag-details',
  standalone: true,
  imports: [CommonModule, RouterLink, ParcelResultsListComponent],
  templateUrl: './bag-details.component.html',
  styleUrl: './bag-details.component.scss'
})
export class BagDetailsComponent {

  route: ActivatedRoute = inject(ActivatedRoute);
  bagType: string = '';
  letterBagService = inject(LetterBagService);
  parcelBagService = inject(ParcelBagService);
  parcelBag: ParcelBag | undefined; 
  letterBag: LetterBag | undefined;
  errorMessage = '';
  shipmentId: string = ''
  loading: boolean = true;

  ngOnInit() {
    const id = this.route.snapshot.params['bagId'];
    this.shipmentId = this.route.snapshot.params['shipmentId'];
    this.bagType = this.route.snapshot.params['type'];
    console.log('Bag ID: ', id);
    console.log(this.bagType);

    if (this.bagType === 'Parcel') {
      this.getParcelBagById(id);
    } else if (this.bagType === 'Letter') {
      this.getLetterBagById(id);
    }

  }

  getLetterBagById(id: string): void {
    this.letterBagService.getLetterBagById(id).subscribe({
      next: (data) => {
        this.letterBag = data;
        console.log('Bag: ', data);
        this.loading = false;
      },
      error: (error: any) => {
        console.error(error);
        this.errorMessage = 'Error retrieving bag: ', error;
        this.loading = false;
      }
    });
  }

  getParcelBagById(id: string): void {
    this.parcelBagService.getParcelBagById(id).subscribe({
      next: (data) => {
        this.parcelBag = data;
        console.log('Bag: ', data);
        this.loading = false;
      },
      error: (error: any) => {
        console.error(error);
        this.errorMessage = 'Error retrieving bag: ', error;
        this.loading = false;
      }
    });
  }
 

}
