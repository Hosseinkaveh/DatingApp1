import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { observable } from 'rxjs';
import { delay } from 'rxjs/operators';
import { AccountService } from '../Services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  model:any = {}
 
  constructor(public accountService:AccountService,private router:Router,private toastr:ToastrService) { }

  ngOnInit(): void {

  }
  
   Login(){
    this.accountService.Login(this.model).subscribe({
      next:response =>{this.toastr.success('login success'),delay(2000)},
      error:error =>{console.log(error),this.toastr.error(error.error,'error'),delay(2000)},
    complete:()=>this.router.navigateByUrl('/home')
    });
    
   }

   LogOut(){
    this.accountService.LogOut();
   
   }
  
}
