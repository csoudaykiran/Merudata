import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/app/models/movie.model';
import { MovieService } from 'src/app/services/movie.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {
  movies: Movie[]=[];

  constructor(private MovieService : MovieService){}

  ngOnInit(): void {
    this.getMovies();
  }
  getMovies() :void {
    this.MovieService.getMovies().subscribe(movies =>{this.movies = movies;
      this.logmoviesdetails();})
  }
  //print movie details in console
  logmoviesdetails(): void {
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
