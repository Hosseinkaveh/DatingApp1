import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from '../Services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
 
  constructor(private accountservice:AccountService,private toastr:ToastrService,private router:Router) {}
  
  canActivate(): Observable<boolean> {
    return this.accountservice.currentUser$.pipe(
      map(user =>{
        if(user) return true;
        this.toastr.error('You shall not pass!');
      })
    )
   
  }
  
}
