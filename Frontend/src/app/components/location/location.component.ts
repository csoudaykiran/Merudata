import { Component, OnInit } from '@angular/core';
import { LocationService } from 'src/app/services/location.service';
@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrls: ['./location.component.css']
})
export class LocationComponent implements OnInit {
  locations: any[] = [];
  newLocationName: string = '';

  constructor(private locationService: LocationService) { }

  ngOnInit(): void {
    this.getLocations();
  }

  getLocations(): void {
    this.locationService.getLocations().subscribe((data: any) => {
      this.locations = data;
    });
  }

  
}