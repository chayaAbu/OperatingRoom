import { Component, OnInit } from '@angular/core';
import { Login } from 'src/app/model/Login';
import { LoginUserService } from 'src/app/service/login-user.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private loginService:LoginUserService) {
    this.myUser=loginService.isLogin
    console.log("nav");
    
    console.log(this.myUser!=undefined);
   }
  myUser:Login|undefined;
  ngOnInit(): void {
  }

}
