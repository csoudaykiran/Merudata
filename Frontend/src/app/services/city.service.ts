import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { City } from '../models/city.model';

@Injectable({
  providedIn: 'root'
})
export class CityService {
  private apiUrl = 'https://localhost:44348/api/City'; // Replace with your API endpoint

  constructor(private http: HttpClient) { }

  getCities(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  addCity(city: City): Observable<City> {
    return this.http.post<City>(this.apiUrl, city);
  }
  
}
