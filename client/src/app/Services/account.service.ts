import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../_models/User';
import {map} from 'rxjs/operators'
import {ReplaySubject} from 'rxjs'
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class AccountService {
   baseUrl = environment.apiUrl;
   private currentUserSource = new ReplaySubject<User>(1);
    currentUser$ = this.currentUserSource.asObservable();

  constructor(private http:HttpClient) { }

  Login(model:any)
  {
   return this.http.post(this.baseUrl+'account/login',model).pipe(
    map((response:User)=>{
      const user = response;
      if(user){
        localStorage.setItem('user',JSON.stringify(user));
        this.setCurrentUser(user);
        
      }

    })
   );
  }
  Register(model:any){
    return this.http.post(this.baseUrl+'account/register',model).pipe(
      map((response:User)=>{
        const user = response;
        if(user){
          localStorage.setItem('user',JSON.stringify(user));
          this.setCurrentUser(user);

        }

      })
    );
  }
  setCurrentUser(user:User){
    this.currentUserSource.next(user)
  }

  LogOut(){
    this.currentUserSource.next(null);
    localStorage.removeItem('user');
  }
}
