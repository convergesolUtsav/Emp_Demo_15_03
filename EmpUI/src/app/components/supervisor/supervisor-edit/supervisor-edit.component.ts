import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ServiceService } from 'src/app/Services/service.service';
import { SupervisorService } from 'src/app/Services/supervisor.service';

@Component({
  selector: 'app-supervisor-edit',
  templateUrl: './supervisor-edit.component.html',
  styleUrls: ['./supervisor-edit.component.css']
})
export class SupervisorEditComponent {
  supervisorData : any;

  supervisorForm = new FormGroup<any>({
    Id : new FormControl(''),
    name : new FormControl('',Validators.required),
    isActive:new FormControl(false),
  })

 superviorId: any = location.pathname.split('/').pop();
 constructor(private _supervisorService: SupervisorService, 
  private router: Router,
  private _mainService : ServiceService
  ){}

 ngOnInit(){
  console.log(this.superviorId);
  
this.getSupervisorById(this.superviorId)

}

editSupervisor(supervisor: any){
  console.log(supervisor  );
  supervisor.Id = this.superviorId;
    this._supervisorService.updateSupervisor(supervisor).subscribe((response : any) =>
    {
      console.log(response);
      if(response.statusCode === 200) {
        this._mainService.Toast.fire({icon: 'success',title: 'Supervisor edit in successfully'});
        this.supervisorForm.reset();
        this.router.navigateByUrl('/supervisor-list');
      }
      else{
        this._mainService.Toast.fire({icon: 'error',title: 'Supervisor not edited in successfully'});

      }
     
    }
    )
  }

getSupervisorById(id :any){
  this._supervisorService.getSupervisorId(id).subscribe((response : any) => 
  {
    this.supervisorData = response.response;
    this.supervisorForm.patchValue({
      Id: this.supervisorData.Id,
      name: this.supervisorData.name,
      isActive: this.supervisorData.isActive
  });
  }
  )
}
}
