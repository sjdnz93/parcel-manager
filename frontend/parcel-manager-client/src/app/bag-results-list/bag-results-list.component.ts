import { Component, Input } from '@angular/core';
import { Bag, LetterBag, ParcelBag } from '../interfaces/bags';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Shipment } from '../interfaces/shipments';

@Component({
  selector: 'app-bag-results-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './bag-results-list.component.html',
  styleUrl: './bag-results-list.component.scss'
})
export class BagResultsListComponent {
  @Input() bag!: Bag;
  @Input() shipmentId!: string;
}
