import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from '../models/user';
import { map } from 'rxjs/operators';
import { __values } from 'tslib';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  user: any;
  userValue: any;
//  private userSubject: BehaviorSubject<User>;
//   public user: Observable<User>;
//    local = localStorage.getItem('user');

//   constructor(private router: Router,
//              private http: HttpClient) 
//              {
//     this.userSubject = new BehaviorSubject<User>(JSON.parse(this.local));
//     this.user = this.userSubject.asObservable();
//   }


//   public get userValue(): User {
//     return this.userSubject.value;
//   }

//   login(userName: string, password: string) {
//     return this.http.post<any>('url/users/login', { userName, password })
//       .pipe(map((user: User) => {
//         localStorage.setItem('user', JSON.stringify(user));
//         this.userSubject.next(user);
//         return user;
//       }));
//   }

//   logout() {
//     localStorage.removeItem('user');
// //this.userSubject.next(null);
//     this.router.navigate(['/login']);

//   }


 }
