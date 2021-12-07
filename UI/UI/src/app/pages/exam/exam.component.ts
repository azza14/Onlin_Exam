import { CategoryService } from './../../services/category.service';
import { category } from './../../models/category';
import { ExamService } from './../../services/exam.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { exam } from 'src/app/models/exam';
import { Router } from '@angular/router';

@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
  styleUrls: ['./exam.component.css'],
})
export class ExamComponent implements OnInit {
  dataSaved=false;
   examList: exam[];
   submitted = false;
   categories: category[];  
   categoryName:any= '';
   examForm: FormGroup;
   examIdUpdate: null;

  constructor (private service: ExamService ,
    private formBuilder: FormBuilder, 
    private categoryService:CategoryService,
    private router: Router) { }

    the_score:number;

  ngOnInit(): void {
    debugger;
    this.getAllExam();
    this.formBuilderExam();
    this.getAllCategories();
  }
  
  //getAllExam
  getAllExam() {
    this.service.getAllExam().subscribe((data) => {
      this.examList = data;      
    });
  } 
  //formBuilderExam  
  formBuilderExam(){
    this.examForm = this.formBuilder.group({
      id: [0],
       title: ["",[Validators.required]],        
       description: ["",[Validators.required]],
       questionsCount: ["",[Validators.required]],  
       score: ["",[Validators.required]],  
       categoryId: ["", [Validators.required]]
     });
 
  } 
  //getAllCategories
  getAllCategories(){

    this.categoryService.getAllcategory().subscribe(data => 
           this.categories = data,  
          error => console.log(error),  () => console.log('Get all Category'));  
  }
  onFormSubmit() {
    this.dataSaved = false;
    debugger;
    this.CreateExam(this.examForm.value);
    this.examForm.reset();
  }
  loadExamToEdit(id:number){
    debugger;
     this.service.getExam(id).subscribe(res => {
      this.dataSaved = false;
      this.examIdUpdate = res.id;
     // this.examIdUpdate = res.Id ;
    this.examForm.controls['title'].setValue(res.Title);
    this.examForm.controls['description'].setValue(res.Description);
    this.examForm.controls['questionsCount'].setValue(res.QuestionsCount);
    this.examForm.controls['score'].setValue(res.Score);
    this.examForm.controls['categoryId'].setValue(res.CategoryId);
    this.examForm.setValue(res);

    });
     }
     CreateExam(exam:any) {
      debugger;
      if (this.examIdUpdate == null) {     
       debugger;
        this.service.addExam(exam).subscribe(
          () => {
            this.dataSaved = true;
            this.getAllExam();
            this.examIdUpdate = null;
            this.examForm.reset();
          }  
        );
      } else
       {
        exam.id = this.examIdUpdate;
        this.service.updateExam(exam.id,exam).subscribe(() => {
          this.dataSaved = true;
          this.getAllExam();
          this.examIdUpdate = null;
          this.examForm.reset();
        });
      }
    }
  
// Delete action
deleteExam(id:number){
    this.service.delete(id).subscribe( response => 
      {
        this.getAllExam();
      },
      error => {console.log(error);});
}

//reset form
  resetForm() {
    this.getAllExam();
    this.examForm.reset();
    this.submitted = false;
  }
getExamInfo(id: any){
  return this.service.getExam(id);
}
  //#region not Used
  getCategoryByName(id){
    this.categoryService.getcategoryByName(id)
    .subscribe((data )=>{
    debugger;
    this.categoryName =  JSON.parse(JSON.stringify(data));
    console.log('categoryName',this.categoryName)
  })}
//#endregion
  
}
