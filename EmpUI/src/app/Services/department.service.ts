import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private http:HttpClient) {}
  
  apiUrl = "http://localhost:5145/";

  createDepartment(data: any){
    
    return this.http.post(`${this.apiUrl}api/Department/createDepartment`,data);
  }

  updateDepartment(data:any){
    console.log(data);
    
    return this.http.put(`${this.apiUrl}api/Department/UpdateDepartment`,data);
    
  }

  getDepartmentId(id: any){
    return this.http.get(`${this.apiUrl}api/Department/GetByIdDepartment?id=${id}`);
  }

  listDepartment(){
    return this.http.get<any>(`${this.apiUrl}api/Department/GetAllDepartments`)
  }

  deleteDepartment(id : any){
    return this.http.delete(`${this.apiUrl}api/Department/DeleteDepartment?id=${id}`);
  }


  getEmployeesByDepartmentId(departmentId: number): Observable<any> {
    return this.http.get<any>(`/api/employees?departmentId=${departmentId}`);
  }
}
