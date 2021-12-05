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
   examList: exam[];
   submitted = false;
   data: any;
   model: any = {};
   EventValue: any = 'Save';
   categories: category[];  
   selectedCategory: number; 
   categoryName:any= '';
  editForm: FormGroup;

  constructor (private service: ExamService ,
    private formBuilder: FormBuilder, 
    private categoryService:CategoryService,
    private router: Router) { }
    examForm: FormGroup;

  ngOnInit(): void {
    this.getAllExam();

    this.examForm = this.formBuilder.group({
     id: [0],
      title: ["",[Validators.required]],        
      description: ["",[Validators.required]],
      questionsCount: ["",[Validators.required]],  
      score: ["",[Validators.required]],  
      categoryId: ["", [Validators.required]]
    });

    this.categoryService.getAllcategory()
      .subscribe(data => this.categories = data,  
      error => console.log(error),  
      () => console.log('Get all Category'));  

     this. getCategoryByName(3);
  }    
  onSubmit() {
    if(this.examForm.valid){
      this.service.addExam(this.examForm.value)
      .subscribe( data => {   
      // console.log('mmm',this.examForm.value);
    //  this.router.navigate(['exam']);
      this.resetForm();
      });   

    } else {
      alert('User form is not valid!!')
      console.log(this.examForm.value)
    }
   
     this.getAllExam();
     
  } 
  getAllExam() {
    this.service.getAllExam().subscribe((data) => {
      this.examList = data;
      console.log('examList',this.examList)
    });
  }

   getCategoryByName(id){
    this.categoryService.getcategoryByName(id)
    .subscribe((data )=>{
    debugger;
    this.categoryName =  JSON.parse(JSON.stringify(data));
    console.log('categoryName',this.categoryName)
  })
}

getExamInfo(id: any){
  return this.service.getExam(id);
}
editExam(id:any){
  this.service.getExam(id)
  .subscribe( data => {
	this.editForm.setValue(data);
  this.editForm.controls['id'].setValue(data.Id);
  });
}

// Delete action
deleteExam(id:number){
  
    this.service.delete(id)
    .subscribe(
      response => {
        this.getAllExam();
      },
      error => {
        console.log(error);
      });
  

}
  // save() {
  //   debugger;
  //   console.log('model' ,this.model);
  //   this.submitted = true;
  //   if (this.examForm.invalid) {
  //     return;
  //   }
  //   this.service.addExam(this.model).subscribe((data) => {
  //     this.data = data;
  //     this.resetForm();
  //   });
  // }

  // update() {
  //   this.submitted = true;
  //   if (this.examForm.invalid) {
  //     return;
  //   }

  //   this.service.updateExam(this.examForm.value).subscribe((data) => {
  //     this.data = data;
  //     this.resetForm();
  //   });
  // }

  // EditData(Data) {
  //   this.examForm.controls['id'].setValue(Data.id);
  //   this.examForm.controls['title'].setValue(Data.title);
  //   this.examForm.controls['description'].setValue(Data.description);
  //   this.examForm.controls['questionsCount'].setValue(Data.questionsCount);
  //   this.examForm.controls['score'].setValue(Data.score);
  //   this.EventValue = 'Update';
  // }

  resetForm() {
    this.getAllExam();
    this.examForm.reset();
    this.EventValue = 'Save';
    this.submitted = false;
  }
}
