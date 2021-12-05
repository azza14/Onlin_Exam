import { category } from './../models/category';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  url = environment.apiUrl;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
  constructor(private http: HttpClient) {}

  //Get All categorys
  getAllcategory(): any {
    
    var result = this.http.get<category[]>(`${this.url}Categories`);
    return result;
  }
  // update 
  updatecategory(category: category): Observable<category> {
    return this.http.put<category>(this.url + 'Categories', category, this.httpOptions);
  }
  // Add
  addcategory(category: category): Observable<category> {
    return this.http.post<category>(
      this.url + 'Categories',
      category,
      this.httpOptions
    );
  }
  // Detail
  getcategory(id: number):any {
    return this.http.get<category>(`${this.url}Categories/${id}`,
      this.httpOptions
    );
  }
   // Search By Name
   findByTitle(name): Observable<any> {
    return this.http.get(`${this.url}?name=${name}`);
  }

  getcategoryByName(id: number): any {
    return this.http.get<category>(
      this.url + 'Categories/GetByName'+'?id='+ id,
      this.httpOptions
    );
  }
  // delete action
  delete(id: any) {
      return this.http.delete(`${this.url}Categories/${id}`); 
  }

  // Handle API errors
  handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(
        `Backend returned code ${error.status}, ` + `body was: ${error.error}`
      );
    }
    return throwError('Something bad happened; please try again later.');
  }
}
