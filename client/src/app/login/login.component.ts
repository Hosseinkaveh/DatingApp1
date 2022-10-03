import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { observable } from 'rxjs';
import { AccountService } from '../Services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  model:any = {}
 
  constructor(public accountService:AccountService,private router:Router) { }

  ngOnInit(): void {

  }
  
   Login(){
    this.accountService.Login(this.model).subscribe({
      next:response =>console.log(response),
      error:error =>console.log(error),
    complete:()=>this.router.navigateByUrl('/home')
    });
    
   }

   LogOut(){
    this.accountService.LogOut();
   
   }
  
}
