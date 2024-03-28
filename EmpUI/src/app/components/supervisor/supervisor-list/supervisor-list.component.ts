import { Component } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ServiceService } from 'src/app/Services/service.service';
import { SupervisorService } from 'src/app/Services/supervisor.service';

@Component({
  selector: 'app-supervisor-list',
  templateUrl: './supervisor-list.component.html',
  styleUrls: ['./supervisor-list.component.css']
})
export class SupervisorListComponent {
  supervisors: any = [];

  constructor(
    private supervisorService : SupervisorService,
    private ngbModal:NgbModal,
    private _mainService : ServiceService
  ){}
  
ngOnInit(){
  this.getAllSupervisor();
}
getAllSupervisor(){
  this.supervisorService.listSupervisor().subscribe({
    next: (res) => {
      this.supervisors = res;
    },
    error:(error) => console.log(error)
  });
}

deleteSupervisor(id: any){
  debugger
  this.supervisorService.deleteSupervisor(id).subscribe((response:any) =>
  {
    console.log(response);
    if(response.statusCode === 200) {
      this._mainService.Toast.fire({icon: 'success',title: 'Supervisor deleted in successfully'});
      this.getAllSupervisor();

    }
    else{
      this._mainService.Toast.fire({icon: 'error',title: 'Supervisor not deleted in successfully'});

    }
    
  })
}



open(data:any,id:any){
  this.ngbModal.open(data,{ size: 'lg' });
  this.supervisorService.getSupervisorId(id).subscribe((response:any)=>{
    if(response.statusCode==200){
      this.supervisors = response.response
    }
  })
}

}
