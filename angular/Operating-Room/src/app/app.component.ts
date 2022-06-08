import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginUserService } from './service/login-user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Operating-Room';
  constructor(private loginService:LoginUserService,private router:Router) { }

  ngOnInit(){
  }
  
}
