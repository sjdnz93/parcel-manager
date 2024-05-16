import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { Shipment } from '../../interfaces/shipments';

@Injectable({
  providedIn: 'root'
})
export class ShipmentService {

  private baseUrl = 'https://localhost:7022';

  constructor(private http: HttpClient) { }

  getAllShipments(): Observable<Shipment[]> {
    return this.http.get<Shipment[]>(`${this.baseUrl}/Shipment`).pipe(
      catchError(error => {
        console.error('An error occurred:', error);
        return throwError(() => `An error occurred while retrieving shipments. Error: ${error}`);
      })
    );
  }

  getShipmentById(id: string): Observable<Shipment> {
    return this.http.get<Shipment>(`${this.baseUrl}/Shipment/${id}`).pipe(
      catchError(error => {
        console.error('An error occurred:', error);
        return throwError(() => `An error occured retrieving shipment. Error: ${error}`);
      })
    );
  }

}
