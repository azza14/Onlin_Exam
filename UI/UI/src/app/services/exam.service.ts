import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { exam } from '../models/exam';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ExamService {
  formData: exam= new exam();
  list : exam[];
  url = environment.apiUrl;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
  constructor(private http: HttpClient) {}
  //Get All exams
  getAllExam(): Observable<exam[]> {
    var result = this.http.get<exam[]>(this.url + 'Exams/GetAll');
    return result;
  }
   //Update Exam
  updateExam( id: number,exam: exam): Observable<exam> {
    return this.http.put<exam>(this.url + 'Exams/Update' + '?id=' + id, exam, this.httpOptions);
  }
  // Cerate Exam  
  addExam(exam: exam): Observable<exam> {
    return this.http.post<exam>(`${this.url}Exams/CreateExam`, exam, this.httpOptions);
  }
  refreshList() {
    this.http.get(this.url)
      .toPromise()
      .then(res =>this.list = res as exam[]);
  }
  //Detail
  getExam(id: number):any {
    return this.http.get<exam>(`${this.url}Exams/${id}`,this.httpOptions);
  }
 
  //get Exam With Questions
  getExamWithQuestions(): Observable<exam> {
    return this.http.get<exam>(this.url + 'Exams/GetExamWithQuestions/');
  }
  // delete action
  delete(id: any) {
    
    return this.http.delete(`${this.url}Exams/${id}`);
    // const ans = confirm(`Do you want to delete exam, with id: ${id}`);
    // if (ans) {
    // }
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
