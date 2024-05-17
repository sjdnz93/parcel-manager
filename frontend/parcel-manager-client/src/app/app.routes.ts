import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ShipmentDetailsComponent } from './shipment-details/shipment-details.component';
import { BagDetailsComponent } from './bag-details/bag-details.component';
import { AddShipmentFormComponent } from './add-shipment-form/add-shipment-form.component';

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
  },

  {
    path: 'shipment/:shipmentId/bag/:bagId',
    component: BagDetailsComponent,
    title: 'Bag Details'
  },

  {
    path: 'create-shipment',
    component: AddShipmentFormComponent,
    title: 'Create Shipment'

  }

];
