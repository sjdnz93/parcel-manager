import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ShipmentDetailsComponent } from './shipment-details/shipment-details.component';


export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    title: 'Home Page'
  },

  {
    path:'shipment/:id',
    component: ShipmentDetailsComponent,
    title: 'Shipment Details'
  }

];
