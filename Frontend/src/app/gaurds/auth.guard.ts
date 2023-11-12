import { AuthService  } from '../services/auth.service';
import { Injectable } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { Observable } from 'rxjs';
import { UrlTree } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class authGaurd  {
  constructor(private auth : AuthService, private router: Router, private toast: NgToastService){

  }
  canActivate(): boolean{
    if(this.auth.isLoggedIn()){
      return true
    }else{
      this.toast.error({detail:"ERROR", summary:"Please Login First!"});
      return false;
    }
  }

}