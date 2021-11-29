import { SharedModule } from './../../shared/shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeRoutingModule } from './employee-routing.module';
import { EmployeeComponent } from './employee.component';

@NgModule({
  imports: [
    CommonModule,
    EmployeeRoutingModule,
    SharedModule
  ],
  declarations: [EmployeeComponent]
})
export class EmployeeModule { }
