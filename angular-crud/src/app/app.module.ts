import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { MatDialogModule } from '@angular/material/dialog';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

import { AppComponent } from './app.component';
import { EmployeesTableComponent } from './components/employees-table/employees-table.component';
import { InsertComponent } from './components/insert/insert.component';
import { SuccessDialogComponent } from './components/success-dialog/success-dialog.component';
import { UpdateComponent } from './components/update/update.component';
import { ConfirmationDialogComponent } from './components/confirmation-dialog/confirmation-dialog.component';

import { AppRoutingModule } from './app-routing.module';

import { DialogService } from './services/dialog.service';

@NgModule({
  declarations: [
    AppComponent,
    EmployeesTableComponent,
    InsertComponent,
    SuccessDialogComponent,
    UpdateComponent,
    ConfirmationDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatTableModule,
    MatIconModule,
    ReactiveFormsModule,
    MatDialogModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  providers: [DialogService],
  bootstrap: [AppComponent]
})
export class AppModule { }