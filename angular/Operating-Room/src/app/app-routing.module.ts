import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HoomComponent } from './componenta/hoom/hoom.component';
import { LoginComponent } from './componenta/login/login.component';
import { RegisterComponent } from './componenta/register/register.component';
import { RoomComponent } from './componenta/room/room.component';
import { SurgeryComponent } from './componenta/surgery/surgery.component';


const routes: Routes = [
  {path:'regis',component:RegisterComponent},
  {path:'surg',component:SurgeryComponent},
  {path:'log',component:LoginComponent},
  {path:'room',component:RoomComponent},
  {path:'hoom',component:HoomComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
