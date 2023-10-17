import { Component, OnInit } from '@angular/core';
import { CityService } from 'src/app/services/city.service';

@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.css']
})
export class CityComponent implements OnInit {
  cities: any[] = [];
  newCityName: string = '';

  constructor(private cityService: CityService) { }

  ngOnInit(): void {
    this.getCities();
  }

  getCities(): void {
    this.cityService.getCities().subscribe((data: any) => {
      this.cities = data;
    });
  }

  addCity(): void {
    if (this.newCityName) {
      this.cityService.addCity({ cityName: this.newCityName }).subscribe((data: any) => {
        this.newCityName = '';
        this.getCities();
      });
    }
  }
}
