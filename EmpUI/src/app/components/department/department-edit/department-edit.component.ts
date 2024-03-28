import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DepartmentService } from 'src/app/Services/department.service';
import { ServiceService } from 'src/app/Services/service.service';

@Component({
  selector: 'app-department-edit',
  templateUrl: './department-edit.component.html',
  styleUrls: ['./department-edit.component.css']
})


export class DepartmentEditComponent {
departmentData : any;

  departmentForm = new FormGroup<any>({
    Id : new FormControl(''),
    name : new FormControl('',Validators.required),
    isActive:new FormControl(false),
  })

  departmentId: any = location.pathname.split('/').pop();


constructor(private departmentService: DepartmentService, 
  private router: Router,
  private _mainService : ServiceService
  ){}

ngOnInit(){
  console.log(this.departmentId);
  
this.getDepartmentById(this.departmentId)

}

editDepartment(department: any){
console.log(this.departmentForm.value);
department.Id = this.departmentId;
  this.departmentService.updateDepartment(this.departmentForm.value).subscribe((response : any) =>
  {
    console.log(response);
    if(response.statusCode === 200) {
      this._mainService.Toast.fire({icon: 'success',title: 'Department edit in successfully'});
      this.departmentForm.reset();
      this.router.navigateByUrl('/department-list');
    }
    else{
      this._mainService.Toast.fire({icon: 'error',title: 'Department not edited in successfully'});

    
  }
 } )
}

getDepartmentById(id :any){
  this.departmentService.getDepartmentId(id).subscribe((response : any) => 
  {
    this.departmentData = response.response;
    this.departmentForm.patchValue({
      Id: this.departmentData.Id,
      name: this.departmentData.name,
      isActive: this.departmentData.isActive
  });
});
}

}
