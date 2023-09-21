import { Component } from '@angular/core';
import { EmployeeService } from '../../services/employee.service';
import { EmployeesDTO } from 'src/app/models/employeesDTO';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { HttpResponse, HttpStatusCode } from '@angular/common/http';
import { DialogService } from 'src/app/services/dialog.service';

@Component({
  selector: 'app-employees-table',
  templateUrl: './employees-table.component.html',
  styleUrls: ['./employees-table.component.css']
})
export class EmployeesTableComponent {
  
  public employee: EmployeesDTO[] = [];
  protected displayedColumns: string[] = ['ID', 'FirstName', 'LastName', 'Title', 
                              'HireDate', 'City', 'Country', 'HomePhone', 'Acciones'];
  protected dataSource = new MatTableDataSource<EmployeesDTO>();

  constructor(private employeeService: EmployeeService, private router: Router,
    private dialogService: DialogService,){

  }

  ngOnInit(): void {
    this.getAllEmployees();
  }

  getAllEmployees(){
    this.employeeService.getAllEmployees().subscribe({
      next:(result: EmployeesDTO[]) => {
        this.employee = result;
        this.dataSource.data = this.employee;
      },
      error:() => {
        this.dialogService.openSuccessDialog("No ha sido posible recuperar la lista de empleados", 1);
      }
    });
  }

  insert(){
    this.router.navigate(['/insert']);
  }

  update(employeeId: number){
    this.router.navigate([`/update/${employeeId}`]);
  }

  delete(employeeId: number){
    this.dialogService.openConfirmationDialog().subscribe((confirmed) => {
      if (confirmed) {
          this.employeeService.deleteEmployee(employeeId).subscribe({
            next: (response:HttpResponse<HttpStatusCode>) => {
              if(response.status == 200){
                this.dialogService.openSuccessDialog("Empleado eliminado exitosamente",0).subscribe(() => {
                    window.location.reload();
                });
              }
            },
            error: () => {
              this.dialogService.openSuccessDialog("No se puede eliminar al empleado", 2);
            }
          });
          
      }
    });
  }
}
