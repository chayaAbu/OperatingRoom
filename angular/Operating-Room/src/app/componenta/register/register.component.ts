import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Register } from 'src/app/model/Register';
import { DbService } from 'src/app/service/db.service';
import { LoginUserService } from 'src/app/service/login-user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerUserForm: any;
  constructor(private db: DbService, private loginService:LoginUserService) { }

  ngOnInit(): void {
    this.registerUserForm = new FormGroup(
      {
        tz: new FormControl(''),
        name: new FormControl(''),
        pass: new FormControl(''),
        nochange: new FormControl(''),
        change: new FormControl(''),



      }
    )
  }

  doRegister() {
    console.log(this.registerUserForm);
    const register: Register = {
      idUser: this.registerUserForm.controls.tz.value,
      userName: this.registerUserForm.controls.name.value,
      password: this.registerUserForm.controls.pass.value,
      changeAvailable: this.registerUserForm.controls.change.value

    }
    console.log(register);
    this.db.registerNewUser(register).subscribe(res => {
      this.loginService.isLogin = res;

      console.log(res)

      if (res == null)
        alert("שגיאת שרת")
      else
        alert("נוסף בהצלחה")
    })
  }

}
