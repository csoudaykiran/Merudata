
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CityService {
  constructor(private http: HttpClient) {}

  //  API endpoint to fetch city names from the backend
  private cityApiUrl = 'https://localhost:44348/api/cities/';

  // Fetch city names
  getCities() {
    return this.http.get<string[]>(this.cityApiUrl);
  }
}