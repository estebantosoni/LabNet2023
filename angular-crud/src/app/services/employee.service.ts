import { HttpClient, HttpResponse, HttpStatusCode } from '@angular/common/http'
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { EmployeesDTO } from 'src/app/models/employeesDTO';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  apiUrl: string = environment.api;

  constructor(private http: HttpClient) { }

  getAllEmployees(): Observable<EmployeesDTO[]>{
    let url = `${this.apiUrl}/empleado`;
    return this.http.get<EmployeesDTO[]>(url);
  }

  getEmployeeById(id: number): Observable<EmployeesDTO>{
    let url = `${this.apiUrl}/empleado/${id}`;
    return this.http.get<EmployeesDTO>(url);
  }

  insertEmployee(employee: EmployeesDTO) : Observable<HttpResponse<HttpStatusCode>>{
    let url = `${this.apiUrl}/empleado`;
    return this.http.post<HttpStatusCode>(url,employee, { observe: 'response' });
  }

  updateEmployee(employee: EmployeesDTO) : Observable<HttpResponse<HttpStatusCode>>{
    let url = `${this.apiUrl}/empleado/${employee.getID}`;
    return this.http.put<HttpStatusCode>(url,employee, { observe: 'response' });
  }

  deleteEmployee(id: number) : Observable<HttpResponse<HttpStatusCode>>{
    let url = `${this.apiUrl}/empleado/${id}`;
    return this.http.delete<HttpStatusCode>(url, { observe: 'response' });
  }

}
