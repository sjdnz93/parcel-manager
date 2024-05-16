import { Component, Input } from '@angular/core';
import { LetterBag, ParcelBag } from '../interfaces/bags';

@Component({
  selector: 'app-bag-results-list',
  standalone: true,
  imports: [],
  templateUrl: './bag-results-list.component.html',
  styleUrl: './bag-results-list.component.scss'
})
export class BagResultsListComponent {
  @Input() bag!: ParcelBag | LetterBag;
}
