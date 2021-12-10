import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path: 'login',
    loadChildren: () => import('./pages/login/login.module').then(m => m.LoginModule)
  },
  {
    path: 'exam',
    loadChildren: () => import('./pages/exam/exam.module').then(m => m.ExamModule)
  },
  {
    path: 'category-list',
    loadChildren: () => import('./pages/category/category.module').then(m => m.CategoryModule)
  },
  
  {
    path: 'employee',
    loadChildren: () => import('./pages/employee/employee.module').then(m => m.EmployeeModule)
  },
  {
    path: 'home',
    loadChildren: () => import('./pages/home/home/home.module').then(m => m.HomeModule)
  },
  {
    path: '**',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: '',
    redirectTo: '',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule { }
