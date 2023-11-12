import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { NgToastModule } from 'ng-angular-popup';
import { MoviesComponent } from './components/movies/movies.component';
import { MovieService } from 'src/app/services/movie.service';
import { CommonModule } from '@angular/common';
import { TheatersComponent } from './components/theaters/theaters.component';
import { BookingComponent } from './components/booking/booking.component';
import { ConfirmationComponent } from './components/confirmation/confirmation.component';
import { UserStoreService } from './services/user-store.service';
import { AuthService } from './services/auth.service';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    DashboardComponent,
    MoviesComponent,
    TheatersComponent,
    BookingComponent,
    ConfirmationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgToastModule,
    FormsModule,
    CommonModule
  ],
  providers: [
    MovieService,
    UserStoreService,
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
