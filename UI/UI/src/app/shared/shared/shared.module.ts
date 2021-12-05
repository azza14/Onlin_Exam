import { SharedRoutingModule } from './shared-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SidebarComponent } from './components/sidebar/sidebar.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [SidebarComponent],
  imports: [
    CommonModule,
    SharedRoutingModule,ReactiveFormsModule
  ],
  exports: [SidebarComponent]
})
export class SharedModule { }
