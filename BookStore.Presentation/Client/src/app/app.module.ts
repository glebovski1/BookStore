import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule} from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app.routing';
import { AuthTest } from './Test';
import { AuthenticationService, RegistrationService, PrintingEditionService, OrderService } from 'app/Service';


import { PurchaseCardComponent } from 'app/purchase-card';
import { PurchaseCardModel } from 'app/models/PurchaseCardModel';
import { PurchaseModel } from 'app/models/purchaseModel';
import { AppComponent } from 'app/app.component';
import { HomeComponent } from 'app/home';
import { LoginComponent } from 'app/login';
import { RegisterComponent } from 'app/register';
import { PrintingEditionComponent } from 'app/printing-edition';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    PrintingEditionComponent,
    PurchaseCardComponent,
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
  providers: [AuthenticationService, RegistrationService, PrintingEditionService, PurchaseCardModel, PurchaseModel, OrderService],
  bootstrap: [AppComponent]
})
export class AppModule { }
