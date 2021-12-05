import { CategoryDetailsComponent } from './category-details/category-details.component';

import { CategoryListComponent } from './category-list/category-list.component';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

export const routes: Routes = [
  {
    path: '',   
    component: CategoryListComponent,
  },
   {
      path:'show/:id',
      component:CategoryDetailsComponent
    },
];
 
  // {
  //   path:'edit/:id',
  //   component:PostEditComponent
  // },
 
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoryRoutingModule { }
