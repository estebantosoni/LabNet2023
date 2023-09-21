import { HttpResponse, HttpStatusCode } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeesDTO } from 'src/app/models/employeesDTO';
import { DialogService } from 'src/app/services/dialog.service';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent {

  protected employeeForm: FormGroup;
  protected formSubmitted: boolean = false;

  constructor(
    private fb: FormBuilder,
    private employeeService: EmployeeService,
    private router: Router,
    private dialogService: DialogService,
    private route: ActivatedRoute,
  ) {
    this.employeeForm = this.fb.group({
      ID: [null],
      FirstName: ['',[Validators.required, Validators.pattern('[A-Za-z]+'), Validators.minLength(3), Validators.maxLength(20)]],
      LastName: ['',[Validators.required, Validators.pattern('[A-Za-z]+'), Validators.minLength(3), Validators.maxLength(20)]],
      Title: ['',[Validators.pattern('([a-zA-Z]{3,}(?:, |$))*[a-zA-Z]{3,}'), Validators.minLength(3), Validators.maxLength(30)]],
      HireDate: [new Date()],
      City: ['',[Validators.pattern('[A-Za-z]+'), Validators.minLength(3), Validators.maxLength(20)]],
      Country: ['',[Validators.pattern('[A-Za-z]+'), Validators.minLength(2), Validators.maxLength(20)]],
      HomePhone: ['',[Validators.pattern(/^\(\d{1,3}\)\s\d{3}-\d{4}$/), Validators.maxLength(14)]]
    });
  }
    
  ngOnInit(): void {
    this.route.params.subscribe(params => {
      const employeeId = +params['id'];
      this.employeeService.getEmployeeById(employeeId).subscribe((employeeData : EmployeesDTO) => {
        this.employeeForm.patchValue(employeeData);
      });
    });
  }

  onSubmit() {
    this.formSubmitted= true;
    
    if (this.employeeForm.valid) {
      const employeeData: EmployeesDTO = this.employeeForm.value;
      this.employeeService.updateEmployee(employeeData).subscribe({
        next: (response:HttpResponse<HttpStatusCode>) => {
        if(response.status == 200){
          this.dialogService.openSuccessDialog('Empleado actualizado exitosamente',0);
          this.router.navigate(['/employee']);
        }},
        error: () => {
          this.dialogService.openSuccessDialog('No ha sido posible actualizar al empleado',1);
          this.router.navigate(['/employee']);
        }
      });
    }
  }

}
