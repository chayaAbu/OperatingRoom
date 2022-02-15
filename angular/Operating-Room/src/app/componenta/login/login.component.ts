import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Login } from 'src/app/model/Login';
import { DbService } from 'src/app/service/db.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginUserForm: any;
  constructor(private db: DbService) { }


  ngOnInit(): void {
    this.loginUserForm = new FormGroup(
      {

        name: new FormControl(''),
        pass: new FormControl(''),




      }
    )
  }

  doLogin() {
    console.log(this.loginUserForm);
    const login: Login = {
      userName: this.loginUserForm.name.value,
      password: this.loginUserForm.pass.value
    }

    console.log(login);
    this.db.loginUser(login).subscribe(res => {
      console.log(res)

      if (res == null)
        alert("שגיאת שרת")
      else
        alert("כניסה למערכת")
    })
  }

}
