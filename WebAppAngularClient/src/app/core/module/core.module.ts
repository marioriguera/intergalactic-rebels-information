/**
 * Angular imports section.
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

/**
 * Third party section.
 */

/**
 * Application imports section
 */
import { CoreRoutingModule } from '../routing/core-routing.module';
import { LayoutModule } from '../../layouts/module/layout.module';
import { SharedModule } from '../../shared/module/shared.module';

/**
 * Components imports section
 */
import { LoginViewComponent } from '../security/views/login-view/login-view.component';
import { LogoutViewComponent } from '../security/views/logout-view/logout-view.component';
import { LoginComponent } from '../security/components/login/login.component';
import { LogoutComponent } from '../security/components/logout/logout.component';
import { ManagerSecurityComponent } from '../security/components/manager-security/manager-security.component';
import { WelcomeViewComponent } from '../welcome/views/welcome-view/welcome-view.component';

@NgModule({
  declarations: [
    LoginViewComponent,
    LogoutViewComponent,
    LoginComponent,
    LogoutComponent,
    ManagerSecurityComponent,
    WelcomeViewComponent
  ],
  imports: [
    CommonModule,
    CoreRoutingModule,
    LayoutModule,
    SharedModule
  ],
  exports: [],
})
export class CoreModule { }
