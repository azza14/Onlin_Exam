import { SharedModule } from './../../shared/shared/shared.module';
import { CategoryRoutingModule } from './category-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoryListComponent } from './category-list/category-list.component';
import { CategoryDetailsComponent } from './category-details/category-details.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    CategoryRoutingModule,
    SharedModule,
    ReactiveFormsModule
  ],
  declarations: [CategoryListComponent, 
    CategoryDetailsComponent]
})
export class CategoryModule { }
