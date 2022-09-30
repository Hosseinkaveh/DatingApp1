import { Component, OnInit } from '@angular/core';
import { AccountService } from '../Services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model:any = {}
  LoggedIn:boolean;

  constructor(private accountService:AccountService) { }

  ngOnInit(): void {
    this.getCurrentUser();
  }
  
   Login(){

    this.accountService.Login(this.model).subscribe({
      next:response =>console.log(response),
      error:error =>console.log(error),
      complete:()=>this.LoggedIn = true
      
    });
    
   }

   getCurrentUser(){
    this.accountService.currentUser$.subscribe(
      {
          next: user=>this.LoggedIn = !!user,
          error:error=>console.log(error)
      });
      
  }
   LogOut(){
    this.accountService.LogOut();
    this.LoggedIn = false;
   }
}
