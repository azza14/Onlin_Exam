import { category } from './../models/category';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  url = environment.apiUrl;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
  constructor(private http: HttpClient) {}
  
  //Get All categorys
  getAllcategory():any {
    debugger;
    var result = this.http.get<category[]>(this.url + '/Categories');
    return result;
  }

  updatecategory(category: category): Observable<category> {
    return this.http.put<category>(this.url, category, this.httpOptions);
  }

  addcategory(category: category): Observable<category> {
    console.log(category);
    return this.http.post<category>(this.url, category, this.httpOptions);
  }

  getcategory(id: number): Observable<category> {
    return this.http.get<category>(this.url + '/' + id);
  }

  delete(id: any) {
    const ans = confirm(`Do you want to delete category, with id: ${id}`);
    if (ans) {
      return this.http.delete(`${this.url}/${id}`);
    }
  }

  // Handle API errors
  handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    return throwError(
      'Something bad happened; please try again later.');
  };

}
