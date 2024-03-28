import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DepartmentService } from 'src/app/Services/department.service';
import { ServiceService } from 'src/app/Services/service.service';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit{
  departmentForm! : FormGroup; 

  constructor(private fb : FormBuilder, 
    private departmentService: DepartmentService, 
    private router: Router,
    private _mainService : ServiceService
    ){}

  ngOnInit(): void {
    this.departmentForm = this.fb.group({
      name:['',Validators.required],
      isActive:[true],
    });
  } 
  onSubmit(data: any){
    debugger
    this.departmentService.createDepartment(data).subscribe((result: any) =>
        {
          console.log(result);
          if(result.statusCode === 200) {
            this._mainService.Toast.fire({icon: 'success',title: 'department add in successfully'});
            
          }
          else{
            this._mainService.Toast.fire({icon: 'error',title: 'department not added in successfully'});
    
          }
          this.departmentForm.reset();
          this.router.navigateByUrl('/department-list');
        }
    
    ) }
  }

