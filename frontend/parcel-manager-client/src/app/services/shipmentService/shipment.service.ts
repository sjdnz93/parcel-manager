import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { Shipment, ShipmentForm } from '../../interfaces/shipments';
import { BagFormSubmit, LetterBag, ParcelBag } from '../../interfaces/bags';

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

  createShipment(request: ShipmentForm): Observable<Shipment> {
    return this.http.post<Shipment>(`${this.baseUrl}/Shipment`, request).pipe(
      catchError(error => {
        console.error('An error occurred:', error.error);
        return throwError(() => `${error.error}`);
      })
    );
  }

  addParcelBagToShipment(id: string, request: BagFormSubmit): Observable<ParcelBag> {
    return this.http.put<ParcelBag>(`${this.baseUrl}/Shipment/${id}/add-parcel-bag`, request).pipe(
      catchError(error => {
        console.error('An error occurred:', error.error);
        return throwError(() => `${error.error}`);
      })
    );
  }


  addLetterBagToShipment(id: string, request: BagFormSubmit): Observable<LetterBag> {
    return this.http.put<LetterBag>(`${this.baseUrl}/Shipment/${id}/add-letter-bag`, request).pipe(
      catchError(error => {
        console.error('An error occurred:', error.error);
        return throwError(() => `${error.error}`);
      })
    );
  }

  finaliseShipment(id: string): Observable<Shipment> {
    return this.http.put<Shipment>(`${this.baseUrl}/Shipment/${id}/finalise-shipment`, {}).pipe(
      catchError(error => {
        console.error('An error occurred:', error.error);
        return throwError(() => `${error.error}`);
      })
    );
  }

}
