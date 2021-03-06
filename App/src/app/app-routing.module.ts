import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';

import { CustomersComponent } from './customers/customers.component';
import { AuthGuard } from './auth/auth.guard';


const routes: Routes = [  
  { path: 'login', component: LoginComponent},
  { path: 'customers', component: CustomersComponent, canActivate: [AuthGuard] },
  { path: '', redirectTo: 'customers', pathMatch: 'full' },
  //{ path: '**', redirectTo: 'login', pathMatch: 'full' },
  
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
