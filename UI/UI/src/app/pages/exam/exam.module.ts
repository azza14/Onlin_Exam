import { SharedModule } from '../../shared/shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ExamRoutingModule } from './exam-routing.module';
import { ExamComponent } from './exam.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  imports: [
    CommonModule,
    ExamRoutingModule,
    ReactiveFormsModule,
     FormsModule,
    ReactiveFormsModule,
    SharedModule
  ],
  declarations: [ExamComponent]
})
export class ExamModule { }
