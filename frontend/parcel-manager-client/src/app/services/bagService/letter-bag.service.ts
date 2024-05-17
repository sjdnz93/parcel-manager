import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { LetterBag } from '../../interfaces/bags';

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
}
