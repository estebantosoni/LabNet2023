import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeService } from 'src/app/services/employee.service'; // Asegúrate de importar tu servicio
import { EmployeesDTO } from 'src/app/models/employeesDTO';
import { DialogService } from 'src/app/services/dialog.service';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-insert',
  templateUrl: './insert.component.html',
  styleUrls: ['./insert.component.css']
})
export class InsertComponent {

  employeeForm: FormGroup;
  formSubmitted: boolean = false;

  constructor(
    private fb: FormBuilder,
    private employeeService: EmployeeService,
    private router: Router,
    private dialogService: DialogService
  ) {
    this.employeeForm = this.fb.group({
      firstName: ['',[Validators.required, Validators.pattern('[A-Za-z]+'), Validators.maxLength(20)]],
      lastName: ['',[Validators.required, Validators.pattern('[A-Za-z]+'), Validators.maxLength(20)]],
      title: ['',[Validators.pattern('[A-Za-z]+'), Validators.maxLength(30)]],
      hireDate: [new Date()],
      city: ['',[Validators.pattern('[A-Za-z]+'), Validators.maxLength(20)]],
      country: ['',[Validators.pattern('[A-Za-z]+'), Validators.maxLength(20)]],
      homePhone: ['',[Validators.pattern(/^\(\d{1,3}\)\s\d{3}-\d{4}$/), Validators.maxLength(14)]]
    });
  }
    
  onSubmit() {
    this.formSubmitted= true;

    if (this.employeeForm.valid) {
      const employeeData: EmployeesDTO = this.employeeForm.value;
      this.employeeService.insertEmployee(employeeData).subscribe((response:HttpResponse<any>) => {
        if(response.status == 200){
          this.dialogService.openSuccessDialog('Empleado agregado exitosamente',true);
          this.router.navigate(['/employee']);
        }
        else{
          this.dialogService.openSuccessDialog('No ha sido posible agregar al empleado',false);
          this.router.navigate(['/employee']);
        }
      });
    }
  }

}
