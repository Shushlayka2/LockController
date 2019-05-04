import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CodeComponent } from './code/code.component';
import { AuthenticationComponent } from './user/authentication.component';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: CodeComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'login',
    component: AuthenticationComponent
  },
  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
