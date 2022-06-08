import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from 'src/app/model/Login';
import { DbService } from 'src/app/service/db.service';
import { LoginUserService } from 'src/app/service/login-user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginUserForm: any;
  constructor(private db: DbService, private loginService: LoginUserService ,private router:Router) { }


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
      userName: this.loginUserForm.controls.name.value,
      password: this.loginUserForm.controls.pass.value
    }

    console.log(login);
    this.db.loginUser(login).subscribe(res => {

      this.loginService.isLogin = res;
      console.log(res)

      if (res == null)
        alert("שגיאת שרת")
      else
        alert("כניסה למערכת")
        this.router.navigate(['hoom'])
    }

    )
  }

  

}
