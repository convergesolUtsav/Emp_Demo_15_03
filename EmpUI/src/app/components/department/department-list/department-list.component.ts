import { Component } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DepartmentService } from 'src/app/Services/department.service';
import { ServiceService } from 'src/app/Services/service.service';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.css']
})
export class DepartmentListComponent {
  departments: any = [];
  department: any = [];


constructor(
  private departmentService : DepartmentService,
  private ngbModal:NgbModal,
  private _mainService : ServiceService
){}

ngOnInit(){
  this.listDepartment();
}
listDepartment(){
  debugger
  this.departmentService.listDepartment().subscribe((response : any) => {
    console.log(response.response);
    this.departments = response.response;
    this.departments = this.departments.reverse()
  })
}



deleteDepartment(id: any){
  debugger
  this.departmentService.deleteDepartment(id).subscribe((response:any) =>
  {
    console.log(response);
    if(response.statusCode === 200) {
      this._mainService.Toast.fire({icon: 'success',title: 'department deleted  successfully'});
      this.listDepartment();
    }
    else{
      this._mainService.Toast.fire({icon: 'error',title: 'Department not deleted because employees are associated with it.'});

    }
   
    
  })
}

open(data:any,id:any){
  this.ngbModal.open(data,{ size: 'lg' });
  this.departmentService.getDepartmentId(id).subscribe((response:any)=>{
    if(response.statusCode==200){
      this.department = response.response

    }
  })
}
}
