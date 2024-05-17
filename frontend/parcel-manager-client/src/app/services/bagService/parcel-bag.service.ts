import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { ParcelBag } from '../../interfaces/bags';
import { ParcelFormSubmit } from '../../interfaces/parcels';

@Injectable({
  providedIn: 'root'
})
export class ParcelBagService {

  private baseUrl = 'https://localhost:7022';

  constructor(private http: HttpClient) { }

  getParcelBagById(id: string): Observable<ParcelBag> {
    return this.http.get<ParcelBag>(`${this.baseUrl}/ParcelBag/${id}`).pipe(
      catchError(error => {
        console.error('An error occurred:', error);
        return throwError(() => `An error occured retrieving parcel bag. Error: ${error}`);
      })
    );
  }

  addParcelToBag(id: string, request: ParcelFormSubmit): Observable<ParcelBag> {
    return this.http.put<ParcelBag>(`${this.baseUrl}/ParcelBag/${id}/add-parcel`, request).pipe(
      catchError(error => {
        console.error('An error occurred:', error.error);
        return throwError(() => `${error.error}`);
      })
    );
  }
}
