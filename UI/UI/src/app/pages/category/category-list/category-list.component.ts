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

  onFormSubmit() {
    this.dataSaved = false;
    debugger;
    this.CreateCategory(this.categoryForm.value);
    this.categoryForm.reset();
  }
  loadCaategoryToEdit(id:number){
    debugger;
     this.service.getcategory(id).subscribe(res => {
      this.dataSaved = false;
      this.categoryIdUpdate = res.id;
      this.categoryForm.controls['name'].setValue(res.name);
      
    });
     }
  CreateCategory(category:any) {
    debugger;
    if (this.categoryIdUpdate == null) {     

      this.service.addcategory(category).subscribe(
        () => {
          this.dataSaved = true;
          this.getAllcategory();
          this.categoryIdUpdate = null;
          this.categoryForm.reset();
        }
      );
    } else {
      category.id = this.categoryIdUpdate;
     
      this.service.updatecategory(category).subscribe(() => {
        this.dataSaved = true;
        this.getAllcategory();
        this.categoryIdUpdate = null;
        this.categoryForm.reset();
      });
    }
  }
  #region 
   // onFormSubmit(){
  //   this.dataSaved= false;
  //   const category= this.categoryForm.value;
    
  //   debugger;
  //   if(category.id==0){
  //     this.createCategory(category);
  //   }
  //   else{
  //     this.Edit(category.id);
  //   }    
  // }
  // createCategory(category:category){
  //   //this.categoryIdUpdate == null
  //     this.service.addcategory(category)
  //     .subscribe(  ()=>{
  //       this.dataSaved=true;
  //       this.message=' Record saved successful';
  //       this.getAllcategory();
  //      // this.categoryIdUpdate= null;
  //       this.categoryForm.reset();
  //     } ); 
  //  }
  //  Edit(id:any){
  //    debugger
     
  //     let category= this.service.getcategory(id);
  //     console.log(category);
  //     this.service.updatecategory(category).subscribe( ()=>{
  //     debugger
  //     this.categoryForm.controls['id'].setValue(id);  
  //     this.categoryForm.controls['name'].setValue(category.name);  
  //     //this.dataSaved= true;
  //     this.message = 'Record Updated Successfully';  
  //     this.getAllcategory();

  //   } );
  //  }
  // loadCaategoryToEdit(id:number){
  //   debugger;
  //  this.service.getcategory(id).subscribe( category=>{
  //     this.message = null;  
  //     this.dataSaved = false;  
  //     this.categoryIdUpdate = category.id;  
  //     this.categoryForm.controls['name'].setValue(category.name);  
  //  // this.categoryForm.controls['id'].setValue(category.id);  
    
  //   // this.dataSaved= true;
  //   // this.message = 'Record Updated Successfully';  
  //   // this.getAllcategory();
  // } );
  // }
  #endregion

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
