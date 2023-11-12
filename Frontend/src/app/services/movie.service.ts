import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CityService } from './city.service';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  private baseUrl = 'https://localhost:44348';

  

  constructor(private http: HttpClient, private city: CityService) {}

  getMoviesByCity(cityID: number) {
    const url = `${this.baseUrl}/api/Movie/ByCity/${cityID}`;
    return this.http.get(url);
    
  }
  getMovieById(id: number)  {
    const url = `${this.baseUrl}/api/Movie/${id}`;
    return this.http.get(url); 
  }
}