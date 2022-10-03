import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { observable } from 'rxjs';
import { AccountService } from '../Services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  @Output() registerMode = new EventEmitter();
  model:any = {}
 
  constructor(public accountService:AccountService) { }

  ngOnInit(): void {

  }
  
   Login(){

    this.accountService.Login(this.model).subscribe({
      next:response =>console.log(response),
      error:error =>console.log(error),
    
      
    });
    
   }

   LogOut(){
    this.accountService.LogOut();
   
   }
   Register(){
    this.registerMode.emit(true);
   }
}
