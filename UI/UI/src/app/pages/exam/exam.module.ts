import { SharedModule } from '../../shared/shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ExamRoutingModule } from './exam-routing.module';
import { ExamComponent } from './exam.component';

@NgModule({
  imports: [
    CommonModule,
    ExamRoutingModule,
    SharedModule
  ],
  declarations: [ExamComponent]
})
export class ExamModule { }
