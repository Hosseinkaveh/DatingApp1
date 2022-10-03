import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AccountService } from './Services/account.service';
import { User } from './_models/User';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{


  constructor(private accountservice:AccountService){}

  ngOnInit() {
    this.setCurrentUser();
  }

  setCurrentUser(){
    const user:User = JSON.parse(localStorage.getItem('user'));
    this.accountservice.setCurrentUser(user);

  }

 
}
