import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginUserForm:any;
  constructor() { }


  ngOnInit(): void {
    this.loginUserForm = new FormGroup(
      {
    
        name: new FormControl(''),
        pass: new FormControl(''),
      
      


      }
    )
  }

}
