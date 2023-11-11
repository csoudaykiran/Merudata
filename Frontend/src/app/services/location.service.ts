import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class LocationService {
  private apiUrl = `${environment.baseUrl}/Location`;

  constructor(private http: HttpClient) {}

  getLocations(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  getLocationById(id: number): Observable<Location> {
    return this.http.get<Location>(`${this.apiUrl}/${id}`);
  }

  addLocation(location: Location): Observable<Location> {
    return this.http.post<Location>(`${this.apiUrl}`, location);
  }

}
