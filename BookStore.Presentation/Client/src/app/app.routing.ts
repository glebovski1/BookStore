import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home';
import { LoginComponent } from './login';
import { RegisterComponent } from './register';
import { PrintingEditionComponent} from './printing-edition';
import { from } from 'rxjs';
import { AuthTest } from './Test';
import { PurchaseCardComponent } from 'app/purchase-card';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'printingEdition', component: PrintingEditionComponent},
    { path: 'test', component: AuthTest},
    {path: 'purchas', component: PurchaseCardComponent},

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const AppRoutingModule = RouterModule.forRoot(routes);
