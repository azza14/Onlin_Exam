import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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

  updateExam(exam: exam): Observable<exam> {
    return this.http.put<exam>(this.url, exam, this.httpOptions);
  }

  addExam(exam: exam): Observable<exam> {
    console.log(exam);
    return this.http.post<exam>(`${this.url}Exams/`, exam, this.httpOptions);
  }
  refreshList() {
    this.http.get(this.url)
      .toPromise()
      .then(res =>this.list = res as exam[]);
  }

  getExam(id: number): Observable<exam> {
    return this.http.get<exam>(this.url +'Exams'+ '/' + id);
  }

  getExamWithQuestions(): Observable<exam> {
    return this.http.get<exam>(this.url + 'Exams/GetExamWithQuestions/');
  }
  delete(id: any) {
    const ans = confirm(`Do you want to delete exam, with id: ${id}`);
    if (ans) {
      return this.http.delete(`${this.url}Exams/${id}`);
    }
  }
}
