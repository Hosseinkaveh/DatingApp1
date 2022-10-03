import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AccountService } from '../Services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['../login/login.component.css']
})
export class RegisterComponent implements OnInit {

  @Output() cancelRegister = new  EventEmitter();
  model:any={};

  constructor(private accountService:AccountService) {
   }

  ngOnInit(): void {
  }

  Register(){
    this.accountService.Register(this.model).subscribe({
      next: response =>console.log(response),
      error: error =>console.log(error),
      complete:()=>this.Cancle()
    });
  }

  Cancle(){
    this.cancelRegister.emit(false);
  }

}
