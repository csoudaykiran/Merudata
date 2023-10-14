import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TestService } from 'src/app/test.service';
//import { TestService } from '../test.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{

  constructor(private service:TestService,private router:Router){

  }

  private movie="ADHIPURUSH";
  private name="AVATAR 2";
  private vera="Veera Simha Reddy";
  private dham="Jailer";
  private pag="Karthikeya 2";
  private varisu="Varisu";
  private ave="Avengers Endgame";
  private antm="ANT-MAN AND THE WASP";
  private jhon="Jhon Wick 4";
  private tran="Transformers";
  private topg="RDX";
  private patan="PATHAAN";
  ngOnInit(): void {
    
  }


  adhi(){
    this.service.variable1 = this.movie;
    this.router.navigate(['booking']);

  }
  ava(){
    this.service.variable1 = this.name;
    this.router.navigate(['booking']);
  }
  veera(){
    this.service.variable1 = this.vera;
    this.router.navigate(['booking']);
  }
  damka(){
    this.service.variable1 = this.dham;
    this.router.navigate(['booking']);
  }
  page(){
    this.service.variable1 = this.pag;
    this.router.navigate(['booking']);
  }
  vari(){
    this.service.variable1 = this.varisu;
    this.router.navigate(['booking']);
  }
  ae(){
    this.service.variable1 = this.ave;
    this.router.navigate(['booking']);
  }
  ant(){
    this.service.variable1 = this.antm;
    this.router.navigate(['booking']);
  }
  jon(){
    this.service.variable1 = this.jhon;
    this.router.navigate(['booking']);
  }
  tra(){
    this.service.variable1 = this.tran;
    this.router.navigate(['booking']);
  }
  top(){
    this.service.variable1 = this.topg;
    this.router.navigate(['booking']);
  }
  pat(){
    this.service.variable1 = this.patan;
    this.router.navigate(['booking']);
  }

}
