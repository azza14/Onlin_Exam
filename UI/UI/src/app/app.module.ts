import { CategoryModule } from './pages/category/category.module';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home/home.component';

@NgModule({
  declarations: [
    AppComponent
    ],    
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule,CategoryModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }


// ng g m shared/shared --routing
// ng g c shared/shared/components/shared --module shared
