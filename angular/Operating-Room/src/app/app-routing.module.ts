import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './componenta/login/login.component';
import { RegisterComponent } from './componenta/register/register.component';
import { SurgeryComponent } from './componenta/surgery/surgery.component';


const routes: Routes = [
  {path:'regis',component:RegisterComponent},
  {path:'surg',component:SurgeryComponent},
  {path:'log',component:LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
