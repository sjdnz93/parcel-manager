import { Component } from '@angular/core';
import { Input } from '@angular/core';
import { Parcel } from '../interfaces/parcels';

@Component({
  selector: 'app-parcel-results-list',
  standalone: true,
  imports: [],
  templateUrl: './parcel-results-list.component.html',
  styleUrl: './parcel-results-list.component.scss'
})
export class ParcelResultsListComponent {
  @Input() parcel!: Parcel;

}
