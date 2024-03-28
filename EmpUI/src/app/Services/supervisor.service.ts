import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SupervisorService {

  constructor(private http:HttpClient) { }
  apiUrl = "http://localhost:5145/";

  createSupervisor(data: any){
    
    console.log(data);
    
    return this.http.post(`${this.apiUrl}api/Supervisor/createSupervisor`,data);
  }
  
  updateSupervisor(data:any){
    console.log(data);
    
    return this.http.put(`${this.apiUrl}api/Supervisor/UpdateSupervisor`,data);
    
  }

  getSupervisorId(id: any){
    return this.http.get(`${this.apiUrl}api/Supervisor/GetByIdSupervisor?id=${id}`);
  }

  listSupervisor(){
    return this.http.get<any>(`${this.apiUrl}api/Supervisor/GetAllSuperviser`)
  }

  deleteSupervisor(id : any){
    return this.http.delete(`${this.apiUrl}api/Supervisor/DeleteSupervisor?id=${id}`);
  }

}
