import { Component } from '@angular/core';
import { EmployeeService } from '../services/employee.service';
import { EmployeeDTO } from 'src/app/models/employeeDTO';

@Component({
  selector: 'app-employees-table',
  templateUrl: './employees-table.component.html',
  styleUrls: ['./employees-table.component.css']
})
export class EmployeesTableComponent {
  
  employee: EmployeeDTO = new EmployeeDTO;

  constructor(private employeeService: EmployeeService){

  }
  
  ngOnInit(): void {
    this.getAllEmployees();
  }

  getAllEmployees(){
    this.employeeService.getAllEmployees().subscribe({
      next:(result) => {
        console.log(result);
        this.employee = result;
      },
      error:(e) => {
        console.log(e);
      }
    })
  }

}
