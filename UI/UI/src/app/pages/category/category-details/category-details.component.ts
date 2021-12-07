import { category } from './../../../models/category';
import { CategoryService } from 'src/app/services/category.service';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-category-details',
  templateUrl: './category-details.component.html',
  styleUrls: ['./category-details.component.css'],
})
export class CategoryDetailsComponent implements OnInit {
  constructor(
    private serveice: CategoryService,
    private route: ActivatedRoute,
    private router: Router
  ) {}
  id: number;  
  categorydata: category;
  ngOnInit(): void {
    debugger;
    this.id = this.route.snapshot.params['id'];

    this.serveice.getcategory(this.id).subscribe((data) => {
      this.categorydata = data;
      console.log(this.categorydata);
    });
  }
}
