import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { category } from './../../../models/category';
import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category.service';


@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']    
})
export class CategoryListComponent implements OnInit {
  dataSaved=false;
  categoryForm: FormGroup;
  categoryList : Observable< category[]>;
  categoryIdUpdate= null;
  message= null;
  data: Object;
  nameCategory: '';
  constructor (private service: CategoryService ,
  private formBuilder: FormBuilder, 
  private router: Router) { }


  ngOnInit(): void {
   this.categoryForm = this.formBuilder.group({
     id:[0],
     name: ["",[Validators.required]],            
  });
  this.getAllcategory();
  }
  onFormSubmit(){
    this.dataSaved= false;
    const category= this.categoryForm.value;
    this.createCategory(category);
    this.categoryForm.reset();
    // if(category.id==0){
    //   this.createCategory(category);
    // }
    // else{
    //   this.loadCaategoryToEdit(category.id);
    // }
   
  }
  createCategory(category:category){
   if(this.categoryIdUpdate== null){
    this.service.addcategory(category)
    .subscribe(  ()=>{
      this.dataSaved=true;
      this.message=' Record saved successful';
      this.getAllcategory();
     this.categoryForm.reset();
    } ); 
   }
   else{
     debugger
     category.id= this.categoryIdUpdate;
     console.log('category.id', category.id)
     this.service.updatecategory(category).subscribe(()=>{
      this.dataSaved=true;
      this.message=' Record saved successful';
      this.getAllcategory();
      this.categoryIdUpdate= null;
     this.categoryForm.reset();
     })
  }
   
}
  loadCaategoryToEdit(id:number){
    debugger;
   this.service.getcategory(id).subscribe( category=>{
      this.message = null;  
      this.dataSaved = false;  
      this.categoryIdUpdate = category.id;  
      this.categoryForm.controls['name'].setValue(category.name);  
   // this.categoryForm.controls['id'].setValue(category.id);  
    
    // this.dataSaved= true;
    // this.message = 'Record Updated Successfully';  
    // this.getAllcategory();

  } );

  }
  onSubmit() {
    if(this.categoryForm.valid){
      this.service.addcategory(this.categoryForm.value)
      .subscribe( data => {   
      this.resetForm();
      });   

    } else {
      alert('User form is not valid!!')
      console.log(this.categoryForm.value)
    }
   
     this.getAllcategory();
     
  }

  getAllcategory() {
    this.service.getAllcategory().subscribe((data) => {
      this.categoryList = data;
      console.log('examList',this.categoryList)
    });
  }
// Delete action
deleteCategory(id:number){
  const ans = confirm(`Do you want to delete exam, with id: ${id}`);
  if (ans) {

    this.service.delete(id)
    .subscribe( ()=>
     { this.dataSaved= true;
       this.message=' Record dalete successful';
        this.getAllcategory();
        this.categoryIdUpdate= null;
        this.categoryForm.reset();
        console.log(id)
      },
      error => {
        console.log(error);
      });
    }
    

}
searchName(): void {
  this.service.findByTitle(this.nameCategory)
    .subscribe(
      data => {
        this.categoryList = data;
        console.log(data);
      },
      error => {
        console.log(error);
      });
}
resetForm() {
    this.categoryForm.reset();
    this.message= null;
     this.dataSaved= false;
    this.getAllcategory();
  }
}
