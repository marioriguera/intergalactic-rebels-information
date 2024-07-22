/**
 * Angular imports section.
 */
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

/**
 * Third party modules.
 */

/**
 * Application imports section
 */
import { AppRoutingModule } from './app-routing.module';
import { SharedModule } from './shared/module/shared.module';
import { CoreModule } from './core/module/core.module';
import { LayoutModule } from './layouts/module/layout.module';

/**
 * Components imports section 
 */
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CoreModule,
    SharedModule,
    LayoutModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
