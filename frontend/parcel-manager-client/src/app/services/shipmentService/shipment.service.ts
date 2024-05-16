import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Shipment } from '../../interfaces/shipments';

@Injectable({
  providedIn: 'root'
})
export class ShipmentService {

  private baseUrl = 'https://localhost:7022';

  constructor(private http: HttpClient) { }

  getAllShipments(): Observable<Shipment[]> {
    return this.http.get<Shipment[]>(`${this.baseUrl}/Shipment`);
  }

}
