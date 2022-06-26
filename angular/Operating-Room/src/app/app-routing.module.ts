import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { DeviceComponent } from './componenta/device/device.component';
import { EmergencyComponent } from './componenta/emergency/emergency.component';
import { HoomComponent } from './componenta/hoom/hoom.component';
import { LoginComponent } from './componenta/login/login.component';
import { RegisterComponent } from './componenta/register/register.component';
import { RoomComponent } from './componenta/room/room.component';
import { SchedulingComponent } from './componenta/scheduling/scheduling.component';
import { SurgeryComponent } from './componenta/surgery/surgery.component';


const routes: Routes = [
  { path: 'regis', component: RegisterComponent },
  { path: 'surg', component: SurgeryComponent },
  { path: 'log', component: LoginComponent },
  { path: 'room', component: RoomComponent },
  { path: 'hoom', component: HoomComponent },
  { path: 'scheduling', component: SchedulingComponent },
  { path: 'device', component: DeviceComponent },
  {path:'emergency',component:EmergencyComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
