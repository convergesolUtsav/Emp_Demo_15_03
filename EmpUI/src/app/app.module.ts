import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {  FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { DepartmentComponent } from './components/department/department.component';
import { DepartmentEditComponent } from './components/department/department-edit/department-edit.component';
import { DepartmentListComponent } from './components/department/department-list/department-list.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SupervisorCreateComponent } from './components/supervisor/supervisor-create/supervisor-create.component';
import { SupervisorEditComponent } from './components/supervisor/supervisor-edit/supervisor-edit.component';
import { SupervisorListComponent } from './components/supervisor/supervisor-list/supervisor-list.component';
import { EmployeeCreateComponent } from './components/employee/employee-create/employee-create.component';
import { EmployeeListComponent } from './components/employee/employee-list/employee-list.component';
import { EmployeeEditComponent } from './components/employee/employee-edit/employee-edit.component';


@NgModule({
  declarations: [
    AppComponent,
    DepartmentComponent,
    DepartmentEditComponent,
    DepartmentListComponent,
    SupervisorCreateComponent,
    SupervisorEditComponent,
    SupervisorListComponent,
    EmployeeCreateComponent,
    EmployeeListComponent,
    EmployeeEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    CommonModule,
    FormsModule,
    NgbModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
