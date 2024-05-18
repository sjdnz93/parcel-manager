import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { LetterBag } from '../../interfaces/bags';
import { LetterBagForm } from '../../interfaces/bags';
import { extractMessages } from '../../helpers/helpers';

@Injectable({
  providedIn: 'root'
})
export class LetterBagService {

  private baseUrl = 'https://localhost:7022';

  constructor(private http: HttpClient) { }

  getLetterBagById(id: string): Observable<LetterBag> {
    return this.http.get<LetterBag>(`${this.baseUrl}/LetterBag/${id}`).pipe(
      catchError(error => {
        console.error('An error occurred:', error);
        return throwError(() => `An error occurred while retrieving letter bag. Error: ${error}`);
      })
    );
  }

  addLettersToBag(id: string, request: LetterBagForm): Observable<LetterBag> {
    return this.http.put<LetterBag>(`${this.baseUrl}/LetterBag/${id}/add-letters`, request).pipe(
      catchError(error => {
        console.error('An error occurred:', error.error);
        if (error.error.errors) {
          const errorMessages = extractMessages(error.error.errors);
          return throwError(() => `${errorMessages}`);
        }
        return throwError(() => `${error.error}`);
      })
    );
  }
}
