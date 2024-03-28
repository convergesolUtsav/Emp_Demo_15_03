import { Component } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { getEmploymentStatus } from 'src/app/Enum/EmploymentStatus';
import { DepartmentService } from 'src/app/Services/department.service';
import { EmployeeService } from 'src/app/Services/employee.service';
import { ServiceService } from 'src/app/Services/service.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent  {
  employees: any = [];
  selectedEmployee: any =  [] = [];
  selectedEmployeeId: any;
  departments: { [id: number]: string } = {};

  constructor(private employeeService : EmployeeService, private ngbModal:NgbModal,
    private departmentService : DepartmentService, 
    private _mainService : ServiceService
    
    ){}

  ngOnInit(){
    this.getAllemployee();
  
  }


  getAllemployee(){
    debugger
  this.employeeService.getAllEmployee().subscribe((response : any) => {
    this.employees = response.response;
    this.employees = this.employees.reverse()
    console.log(this.employees);
  })
  }

  deleteEmployee(id: any){
    debugger
    this.employeeService.deleteEmployee(id).subscribe((response:any) =>
    {
      console.log(response);
  
      if(response.statusCode === 200) {
        this._mainService.Toast.fire({icon: 'success',title: 'Employee deleted in successfully'});
        
     this.getAllemployee();
      }
      else{
        this._mainService.Toast.fire({icon: 'error',title: 'Employee not deleted in successfully'});

      }

      
    })
  }

  open(content: any, id: any) {
    this.selectedEmployeeId = id;
    this.loadDepartments();
    this.ngbModal.open(content, { size: 'lg' });
    this.employeeService.getEmployeeId(id).subscribe((response: any) => {
      if (response.statusCode == 200) {
        this.selectedEmployee = response.response;
      }
    });
  }

  getAddress(employee: any): string {
    return `${employee?.address?.street}, ${employee?.address?.city}, ${employee?.address?.state}, ${employee?.address?.zip}`;
  }

  getEmergencyContact(employee: any): string {
    return `${employee?.emergencyContact?.personName}, ${employee?.emergencyContact?.phoneNumber}, ${employee?.emergencyContact?.relation}, ${employee?.emergencyContact?.street}, ${employee?.emergencyContact?.city}, ${employee?.emergencyContact?.state}, ${employee?.emergencyContact?.zip}`;
  }


  
  loadDepartments() {
    this.departmentService.listDepartment().subscribe((departments: any) => {
      Object.keys(departments).forEach((key: any) => {
        const department = departments[key];    
        this.departments[department.id] = department.name;
      });
    });
  }
  

  getDepartmentName(id: number): string {
    const departmentName = this.departments[id];
    console.log(this.departments);
    
    return departmentName ;
  }
  getEmpStatus(state: number): string
{
  return getEmploymentStatus(state).toString();
}
}
