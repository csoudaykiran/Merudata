import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { CityService } from 'src/app/services/city.service';
import { UserStoreService } from 'src/app/services/user-store.service';
import { Router } from '@angular/router';
import {  Renderer2, ElementRef } from '@angular/core';



@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  cities: any[] = [];
  selectedCity: string | null = null;
  selectedCityID: number | null = null;
  filteredCities: any[] = [];
  cityFilter: string = '';
  public users: any[] = [];
  public fullName: string = '';
  
  constructor(
    private cityService: CityService,
    private auth: AuthService,
    private userstore: UserStoreService,
    private router: Router,
    private renderer: Renderer2,
    private el: ElementRef
  ) {}

  ngOnInit() {
    this.renderer.setStyle(document.body, 'background-color', 'lavender');
    this.cityService.getCities().subscribe((data: any) => {
      if (Array.isArray(data.$values)) {
        this.cities = data.$values;
      } else {
        console.error('Unexpected data structure:', data);
      }
      this.filteredCities = this.cities;
      console.log(this.cities);
    });
    
    this.userstore.setFullNameForStore(this.auth.getfullNameFromToken());
    this.userstore.getFullNameFromStore().subscribe(val => {
      this.fullName = val ;
    });
  }
  selectCity(city: any) {
    // Extract the city ID
    this.selectedCityID = city.cityID;
    
    // Set the selected city name
    this.selectedCity = city.cityName;

    this.userstore.setFullNameForStore(this.auth.getfullNameFromToken());
    
    // Use the Angular router to navigate to the "movies" route with the selected city as a parameter
    this.router.navigate(['/movies', this.selectedCityID],{
      queryParams: { fullName: this.fullName }
    });
  }

  filterCities() {
    if (this.cityFilter) {
      this.filteredCities = this.cities
        .filter(city => city.cityName.toLowerCase().includes(this.cityFilter.toLowerCase()))
        .sort((a, b) => a.cityName.localeCompare(b.cityName));
    } else {
      // Display all cities when the search input is cleared
      this.filteredCities = this.cities.slice().sort((a, b) => a.cityName.localeCompare(b.cityName));
    }
  }

  logout() {
    this.auth.signOut();
  }
}
