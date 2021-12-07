import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ExamDetailsComponent } from './exam-details/exam-details.component';

import { ExamComponent } from './exam.component';

const routes: Routes = [
  {
    path: '',
    component: ExamComponent
  },
  {
    path:'details/:id',
    component:ExamDetailsComponent
  }
];  

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExamRoutingModule { }  
