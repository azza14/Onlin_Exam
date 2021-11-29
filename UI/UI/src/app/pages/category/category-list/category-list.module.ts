import { SharedModule } from './../../../shared/shared/shared.module';
import { CategoryListRoutingModule } from './category-list-routing.module';
import { CategoryListComponent } from './category-list.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [
    CommonModule,
    CategoryListRoutingModule,
    SharedModule
  ],
  declarations: [CategoryListComponent]
})
export class CategoryListModule { }
