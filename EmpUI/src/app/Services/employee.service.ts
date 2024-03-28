import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {


  constructor(private http:HttpClient) { }
  apiUrl = "http://localhost:5145/";

  createEmployee(data : any)
  {
    return this.http.post(`${this.apiUrl}api/Employee/createEmployee`,data);  
  }

  updateEmployee(data: any){
    return this.http.put(`${this.apiUrl}api/Employee/UpdateEmployee`,data);
  }

  getEmployeeId(id:any){
    return this.http.get(`${this.apiUrl}api/Employee/GetByIdEmployee?id=${id}`);
  }

  getAllEmployee(){
    return this.http.get(`${this.apiUrl}api/Employee/GetAllEmployee`);
  }

  deleteEmployee(id : any){
    return this.http.delete(`${this.apiUrl}api/Employee/DeleteEmployee?id=${id}`);
  }
}
