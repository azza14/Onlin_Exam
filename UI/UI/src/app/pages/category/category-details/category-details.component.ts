import { CategoryService } from 'src/app/services/category.service';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-category-details',
  templateUrl: './category-details.component.html',
  styleUrls: ['./category-details.component.css']
})
export class CategoryDetailsComponent implements OnInit {
  @Input() itemId:any ;
  addForm:FormGroup;
   itemDetail :any={};
   @Output() items= new EventEmitter<any>();
   router: any;
   constructor( private fb:FormBuilder,private service:CategoryService) { }
 
   ngOnInit(): void {
     this.getCategoryDetail(this.itemId);
   }
   
   getCategoryDetail(id){
     this.service.getcategory(id).subscribe(res=>{
       this.itemDetail=res;
       console.log(this.itemDetail);

     })
   }

   goBack(){
      this.router.navigate(['./category-list']);

   }
   }