import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginViewComponent } from '../security/views/login-view/login-view.component';
import { LogoutViewComponent } from '../security/views/logout-view/logout-view.component';

export const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'login',
        component: LoginViewComponent,
        data: {
          animation: 'LoginPage'
        }
      },
      {
        path: 'logout',
        component: LogoutViewComponent,
        data: {
          animation: 'LogoutPage'
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CoreRoutingModule { }
