import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InsertComponent } from './components/insert/insert.component';
import { EmployeesTableComponent } from './components/employees-table/employees-table.component';
import { UpdateComponent } from './components/update/update.component';

const routes: Routes = [
  { path: 'employee', component: EmployeesTableComponent },
  { path: 'insert', component: InsertComponent },
  { path: 'update/:id', component: UpdateComponent },
  { path: '', redirectTo: '/employee', pathMatch: 'full' }, //ruta por defecto
  {path: '**', redirectTo: '/employee', pathMatch: 'full' } //ruta inexistente
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
