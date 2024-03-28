import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartmentComponent } from './components/department/department.component';
import { DepartmentEditComponent } from './components/department/department-edit/department-edit.component';
import { DepartmentListComponent } from './components/department/department-list/department-list.component';
import { SupervisorCreateComponent } from './components/supervisor/supervisor-create/supervisor-create.component';
import { SupervisorListComponent } from './components/supervisor/supervisor-list/supervisor-list.component';
import { SupervisorEditComponent } from './components/supervisor/supervisor-edit/supervisor-edit.component';
import { EmployeeCreateComponent } from './components/employee/employee-create/employee-create.component';
import { EmployeeListComponent } from './components/employee/employee-list/employee-list.component';
import { EmployeeEditComponent } from './components/employee/employee-edit/employee-edit.component';

const routes: Routes = [
  { path: 'department', component: DepartmentComponent },
  { path: 'department-edit/:id', component: DepartmentEditComponent },
  { path: 'department-list', component: DepartmentListComponent },
  { path: 'supervisor', component: SupervisorCreateComponent },
  { path: 'supervisor-list', component: SupervisorListComponent },
  { path: 'supervisor-edit/:id', component: SupervisorEditComponent },
  { path: 'employee-create', component: EmployeeCreateComponent },
  { path: 'employee-edit/:id', component: EmployeeEditComponent },
  { path: 'employee-list', component: EmployeeListComponent },
  { path: '', component: EmployeeListComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
