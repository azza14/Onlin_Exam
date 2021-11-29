import { category } from './../../../models/category';
import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {
 categoryList : category[];
  constructor( private service: CategoryService) { }

  ngOnInit(): void {
    debugger;
    this.service.getAllcategory().subscribe(data =>{
      this.categoryList= data;
    });

  
  }

}
