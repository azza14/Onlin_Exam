import { SharedRoutingModule } from './shared-routing.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SidebarComponent } from './components/sidebar/sidebar.component';


@NgModule({
  declarations: [SidebarComponent],
  imports: [
    CommonModule,
    SharedRoutingModule
  ],
  exports: [SidebarComponent]
})
export class SharedModule { }
