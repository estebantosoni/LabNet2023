import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/app/environments/environment';
import { EmployeeDTO } from 'src/app/models/employeeDTO';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  apiUrl: string = environment.api;

  constructor(private http: HttpClient) { }

  getAllEmployees(): Observable<EmployeeDTO>{
    let url = `${this.apiUrl}/empleado/GetEmpleados`;
    return this.http.get<EmployeeDTO>(url);
  }

}
