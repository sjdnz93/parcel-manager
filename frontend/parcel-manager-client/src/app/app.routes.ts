import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ShipmentDetailsComponent } from './shipment-details/shipment-details.component';
import { BagDetailsComponent } from './bag-details/bag-details.component';
import { AddShipmentFormComponent } from './add-shipment-form/add-shipment-form.component';
import { AddBagFormComponent } from './add-bag-form/add-bag-form.component';
import { AddParcelFormComponent } from './add-parcel-form/add-parcel-form.component';
import { AddLettersFormComponent } from './add-letters-form/add-letters-form.component';

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

  },

  {
    path: 'shipment/:shipmentId/add-bag',
    component: AddBagFormComponent,
    title: 'Create Parcel Bag'
  },

  {
    path: 'shipment/:shipmentId/parcel-bag/:bagId/add-parcel',
    component: AddParcelFormComponent,
    title: 'Add Parcel'
  },

  {
    path: 'shipment/:shipmentId/bag/:bagId/add-letters',
    component: AddLettersFormComponent,
    title: 'Add Letters'
  }

];
