import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SurgeryComponent } from './componenta/surgery/surgery.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './componenta/register/register.component';
import { LoginComponent } from './componenta/login/login.component';
import { RoomComponent } from './componenta/room/room.component';
import { DeviceComponent } from './componenta/device/device.component';

@NgModule({
  declarations: [
    AppComponent,
    SurgeryComponent,
    RegisterComponent,
    LoginComponent,
    RoomComponent,
    DeviceComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
