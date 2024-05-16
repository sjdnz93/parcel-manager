import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    title: 'Home Page'
  },

  // {
  //   path:'shipments/:id',
  //   component: ShipmentDetailsComponent,
  //   title: 'Shipment Details'
  // }

];
