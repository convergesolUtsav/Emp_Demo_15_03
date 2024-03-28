import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ServiceService } from 'src/app/Services/service.service';
import { SupervisorService } from 'src/app/Services/supervisor.service';

@Component({
  selector: 'app-supervisor-create',
  templateUrl: './supervisor-create.component.html',
  styleUrls: ['./supervisor-create.component.css']
})
export class SupervisorCreateComponent {
  
  supervisorForm! : FormGroup; 
  constructor(private _fb : FormBuilder, 
    private _supervisorService: SupervisorService,
      private router: Router,
      private _mainService : ServiceService
      
      ){}

  ngOnInit(): void {
  this.supervisorForm =this._fb.group({
    name:['',Validators.required],
      isActive:[true],
  })
}
createSupervisor(data : any){
  debugger
  this._supervisorService.createSupervisor(data).subscribe((result: any) =>
  {
    console.log(result);
    if(result.statusCode === 200) {
      this._mainService.Toast.fire({icon: 'success',title: 'Supervisor add in successfully'});
      this.supervisorForm.reset();
      this.router.navigateByUrl('/supervisor-list');
    }
    else{
      this._mainService.Toast.fire({icon: 'error',title: 'Supervisor not added in successfully'});

    }
  
   
  })

}

}
