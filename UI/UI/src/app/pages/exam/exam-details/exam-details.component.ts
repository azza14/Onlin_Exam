import { ExamService } from './../../../services/exam.service';
import { exam } from 'src/app/models/exam';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-exam-details',
  templateUrl: './exam-details.component.html',
  styleUrls: ['./exam-details.component.css']
})
export class ExamDetailsComponent implements OnInit {

  constructor( private serveice:ExamService,
                private route:ActivatedRoute,  
                private router: Router) { }
  id: number;
  examdata: exam;
  ngOnInit(): void {
    debugger
     this.id= this.route.snapshot.params['id'];

     this.serveice.getExam(this.id).subscribe(data=>{
       this.examdata=data;
       console.log( this.examdata)
     });
  }

}
