import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../Services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['../login/login.component.css']
})
export class RegisterComponent implements OnInit {
  
  model:any={};

  constructor(private accountService:AccountService,private router:Router ) {
   }

  ngOnInit(): void {
  }

  Register(){
    this.accountService.Register(this.model).subscribe({
      next: response =>console.log(response),
      error: error =>console.log(error),
      complete:()=>this.router.navigateByUrl('/home')
    });
  }

  

}
