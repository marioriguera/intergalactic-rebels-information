/**
 * Angular imports section.
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

/**
 * Third party modules
*/

/**
 * Application imports section
*/

/**
 * Components imports section 
*/
import { DashboardComponent } from '../views/dashboard/dashboard.component';


@NgModule({
  declarations: [
    DashboardComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    DashboardComponent
  ]
})
export class LayoutModule { }
