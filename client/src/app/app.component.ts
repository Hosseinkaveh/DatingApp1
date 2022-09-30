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
  title = 'reload...';
  users:any;
  constructor(private http:HttpClient,private accountservice:AccountService){

  }
  ngOnInit() {
    this.setCurrentUser();
    this.getUsers();
  }
  setCurrentUser(){
    const user:User = JSON.parse(localStorage.getItem('user'));
    this.accountservice.setCurrentUser(user);

  }


  getUsers(){
    this.http.get('https://localhost:5001/api/users').subscribe({
      next:response =>this.users = response,
      error:error =>console.log(error)
  })
  }

 
}
