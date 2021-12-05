import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class UserService {
  
  url = environment.apiUrl;
    httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
  constructor(private http:HttpClient) { }
  
  getAll(){
    return this.http.get<User[]>('');
  }
  getById(id:number){
    return this.http.get<User>('');
  }
  login(login:any){
    return this.http.post(this.url+'Users/Login', login, this.httpOptions); 
   }
 
}
