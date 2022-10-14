import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

const httpOptions =  {
  headers: new HttpHeaders({
    Authorization:'Bearer '+JSON.parse(localStorage.getItem('user'))?.tokenKey
  })
}

@Injectable({
  providedIn: 'root'
})

export class MembersService {
  baseUrl = environment.apiUrl;

  constructor(private http:HttpClient) { }

  getMembers(){
   return this.http.get(this.baseUrl+ 'users',httpOptions)
  }
  getMember(username:string)
  {
    return this.http.get(this.baseUrl+'users',httpOptions)
  }

}
