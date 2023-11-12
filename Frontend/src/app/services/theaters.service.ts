// theater.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TheaterService {
  private baseUrl = 'https://localhost:44348/api/Screens';

  constructor(private http: HttpClient) {}

  // Define a method to get theaters by movieId
  getTheatersByMovie(movieId: number): Observable<any> {
    const url = `${this.baseUrl}/movie/${movieId}`;
    return this.http.get<any>(url);
  }
}
