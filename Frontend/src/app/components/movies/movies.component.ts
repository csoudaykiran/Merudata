import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/app/models/movie.model';
import { MovieService } from 'src/app/services/movie.service';
import { LocationService } from 'src/app/services/location.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {
  movies: Movie[]=[];
  locations:any[]=[];
  
  

  constructor(private MovieService : MovieService,private locationService: LocationService){}

  ngOnInit(): void {
    this.getMovies();
    this.getLocations();
    this.logmoviesdetails();
  }
  getMovies() :void {
    this.MovieService.getMovies().subscribe(movies =>{this.movies = movies;
      this.mapLocationsToMovies();
      this.logmoviesdetails()
    });
  }

  getLocations(): void {
    this.locationService.getLocations().subscribe((locations: any[]) => {
      this.locations = locations;
      this.mapLocationsToMovies();
      console.log(locations);
    });
  }

  // Map location information to movies
  mapLocationsToMovies(): void {
    if (this.movies && this.locations) {
      this.movies.forEach(movie => {
        const location = this.locations.find(loc => loc.locationID === movie.locationId);
        if (location) {
          movie.location = location;
        }
      });
    }
  }

  

  //print movie details in console
  logmoviesdetails(): void {

    this.mapLocationsToMovies();
    if (this.movies){
      this.movies.forEach(movie =>{
        console.log('Movie Title:', movie.title);
        console.log('Image Link:', movie.imgLink);
        console.log('Description:', movie.description);
        console.log('Duration:', movie.duration, 'minutes');
        console.log('Language:', movie.language);
        console.log('Release Date:', movie.releaseDate);
        console.log('Censorship:', movie.censorship);
        console.log('Country:', movie.country);
        console.log('Trailer Link:', movie.trailerLink);
        console.log('----------------------------------------');
      });
    }
  }

}
