import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { HomeComponent } from './home';
import { LoginComponent } from './login';
import { RegisterComponent } from './register';
import { PrintingEditionComponent } from './printing-edition';
import { AppRoutingModule } from './app.routing';
import { AuthTest } from './Test';
import { AuthenticationService, RegistrationService, PrintingEditionService } from './service';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    PrintingEditionComponent,
    AuthTest,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
  ],
  providers: [AuthenticationService, RegistrationService, PrintingEditionService],
  bootstrap: [AppComponent]
})
export class AppModule { }
