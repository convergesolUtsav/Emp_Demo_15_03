import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
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
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.css']
})


export class EmployeeEditComponent {
employeeData : any;
addresses!: FormArray;
emergencyContacts! : FormArray;
departmentList : { [key: string]: string } = {};
supervisorList : { [key: string]: string } = {};

  constructor(private _employeeService : EmployeeService, private _fb : FormBuilder, private router: Router,
    private departmentService: DepartmentService,
    private supervisorService: SupervisorService,
    private _mainService : ServiceService
    ){
      this.addresses = this._fb.array([]);
    // Update the addresses property in the form group
    this.employeeForm.setControl('addresses', this.addresses);

    this.emergencyContacts = this._fb.array([]);
this.employeeForm.setControl('emergencyContacts', this.emergencyContacts);
    }


  employmentStatuses = [
    { name: 'Active', value: EmploymentStatus.Active },
    { name: 'On Leave', value: EmploymentStatus.OnLeave },
    { name: 'Terminated', value: EmploymentStatus.Terminated }
  ];
  employeeForm = new FormGroup<any>({
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

  })
  addAddress() {
    
    const addressGroup = this._fb.group({
      id : [],
      street: ['', Validators.required],
      city: ['', Validators.required],
      state: ['', Validators.required],
      zip: ['', Validators.required]
    });

    if (this.addresses) {
      this.addresses.push(addressGroup);
    }
  }


  addEmergencyContact() {
    const emergencyContactGroup = this._fb.group({
      id : [],
      personName: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      relation: ['', Validators.required],
      street: ['', Validators.required],
      city: ['', Validators.required],
      state: ['', Validators.required],
      zip: ['', Validators.required]
    });
    if (this.emergencyContacts) {
      this.emergencyContacts.push(emergencyContactGroup);
    }
  }









  employeeId: any = location.pathname.split('/').pop();
  
ngOnInit(){
 // console.log(this.employeeId);
 this.GetAlldepartment();
 this.getAllSupervisor();
this.getEmployeeById(this.employeeId)

}


editDepartment(employee: any){
  debugger
  employee.Id = this.employeeId;
    this._employeeService.updateEmployee(employee).subscribe((response : any) =>
    {
      console.log(response);
      if(response.statusCode === 200) {
        this._mainService.Toast.fire({icon: 'success',title: 'Supervisor edit in successfully'});
        this.employeeForm.reset();
        this.router.navigateByUrl('/employee-list');
      }
      else{
        this._mainService.Toast.fire({icon: 'error',title: 'Supervisor not edited in successfully'});
  
     
    }
  });
  }


  getEmployeeById(id : any){
    this._employeeService.getEmployeeId(id).subscribe((response : any) => 
  {
    this.employeeData = response.response;
    this.employeeForm.patchValue({
      Id: this.employeeData.Id,
      firstName: this.employeeData.firstName,
      lastName: this.employeeData.lastName,
      dateOfBirth: this.employeeData.dateOfBirth,
      gender: this.employeeData.gender,
      emailAddress: this.employeeData.emailAddress,
      departmentID: this.employeeData.departmentID,
      phoneNumber: this.employeeData.phoneNumber,
      salary: this.employeeData.salary,
      position: this.employeeData.position,
      dateHired: this.employeeData.dateHired,
      supervisorId: this.employeeData.supervisorId.toString(),
      employmentStatus: this.employeeData.employmentStatus.toString(),
  });

  if (this.employeeData.addresses) {
    this.employeeData.addresses.forEach((address: any) => {
      this.addresses.push(this._fb.group({
        id: address.id,
        street: address.street,
        city: address.city,
        state: address.state,
        zip: address.zip
      }));
    });

    }


    if (this.employeeData.emergencyContacts) {
      this.employeeData.emergencyContacts.forEach((emergencyContact: any) => {
        this.emergencyContacts.push(this._fb.group({
          id: emergencyContact.id,
          personName:emergencyContact.personName ,
          phoneNumber: emergencyContact.phoneNumber,
          relation: emergencyContact.relation,
          street: emergencyContact.street,
          city: emergencyContact.city,
          state: emergencyContact.state,
          zip: emergencyContact.zip
        }));
      });

      }

});
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
    this.addresses.removeAt(index);
  }
}
