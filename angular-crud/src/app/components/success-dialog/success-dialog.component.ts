import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-success-dialog',
  templateUrl: './success-dialog.component.html',
  styleUrls: ['./success-dialog.component.css'],
})
export class SuccessDialogComponent {
  
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: { message: string, n: number },
    private dialogRef: MatDialogRef<SuccessDialogComponent>
  ) {}

  closePopup() {
    this.dialogRef.close();
  }

}


