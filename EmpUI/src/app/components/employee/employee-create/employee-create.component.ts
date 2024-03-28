import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { DepartmentService } from 'src/app/Services/department.service';
import { EmployeeService } from 'src/app/Services/employee.service';
import { ServiceService } from 'src/app/Services/service.service';
import { SupervisorService } from 'src/app/Services/supervisor.service';

export enum EmploymentStatus {
  Active = 1,
  OnLeave = 2,
  Terminated = 3
}

@Component({
  selector: 'app-employee-create',
  templateUrl: './employee-create.component.html',
  styleUrls: ['./employee-create.component.css']
})
export class EmployeeCreateComponent {
  
  constructor(
    private fb: FormBuilder,
    private departmentService: DepartmentService,
    private supervisorService: SupervisorService,
    private employeeService: EmployeeService,
    private _mainService : ServiceService,
    private _router: Router
  ){ }
  
  addresses!: FormArray;
  emergencyContacts!: FormArray;
  departmentList : { [key: string]: string } = {};
  supervisorList : { [key: string]: string } = {};
  
  employmentStatuses = [
    { name: 'Active', value: EmploymentStatus.Active },
    { name: 'On Leave', value: EmploymentStatus.OnLeave },
    { name: 'Terminated', value: EmploymentStatus.Terminated }
  ];

  ngOnInit(): void{
    this.addresses = this.employeeForm.get('addresses') as FormArray;
  this.emergencyContacts = this.employeeForm.get('emergencyContacts') as FormArray;
    this.GetAlldepartment();
    this.getAllSupervisor();
  }

  employeeForm = new FormGroup({
    firstName : new FormControl('', [Validators.required]),
    lastName : new FormControl('', [Validators.required]),
    dateOfBirth : new FormControl('', [Validators.required]),
    gender : new FormControl('', [Validators.required]),
    emailAddress : new FormControl('', [Validators.required]),
    phoneNumber : new FormControl('', [Validators.required]),
    departmentID : new FormControl('', [Validators.required]),
    position : new FormControl('', [Validators.required]),
    salary : new FormControl('', [Validators.required]),
    dateHired : new FormControl('', [Validators.required]),
    supervisorId : new FormControl('', [Validators.required]),
    employmentStatus : new FormControl('', [Validators.required]),
    addresses: this.fb.array([]),
    emergencyContacts: this.fb.array([]),
  });


  addAddress() {
    debugger
    const addressGroup = this.fb.group({
      street: ['', Validators.required],
      city: ['', Validators.required],
      state: ['', Validators.required],
      zip: ['', [Validators.required, Validators.pattern(/^\d{6}$/)]]
    });

    (this.employeeForm.get('addresses') as FormArray).push(addressGroup);
  }

  addEmergencyContact() {
    const emergencyContactGroup = this.fb.group({
      personName: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      relation: ['', Validators.required],
      street: ['', Validators.required],
      city: ['', Validators.required],
      state: ['', Validators.required],
      zip: ['', Validators.required],
    });
  
   ( this.employeeForm.get('emergencyContacts') as FormArray).push(emergencyContactGroup);
  }




  onSubmit(data: any){
    data.employmentStatus = +data.employmentStatus;
    this.employeeService.createEmployee(data).subscribe((result :any) =>
    {
      console.log(result);
      if(result.statusCode === 200) {
        this._mainService.Toast.fire({icon: 'success',title: 'Employee add in successfully'});
        this.employeeForm.reset();
        this._router.navigateByUrl('/employee-list');
      }
      else{
        this._mainService.Toast.fire({icon: 'error',title: 'Employee not added in successfully'});

      }

     
    })
  }


  GetAlldepartment(){
    this.departmentService.listDepartment().subscribe((data:any) =>{
      if (data.statusCode == 200) {
        for (let i in data.response) {
          this.departmentList[data.response[i].id] = data.response[i].name;
        }
      }
    })
  }


  getAllSupervisor(){
    this.supervisorService.listSupervisor().subscribe((data:any) => {
      if (data.statusCode == 200) {
        for (let i in data.response) {
          this.supervisorList[data.response[i].id] = data.response[i].name;
        }
      }
    })
  }

  deleteAddress(index: number) {
    this.addresses.removeAt(index);
  }

  

  deleteEmergencyContact(index: number) {
    this.emergencyContacts.removeAt(index);
  }


  
 
}
