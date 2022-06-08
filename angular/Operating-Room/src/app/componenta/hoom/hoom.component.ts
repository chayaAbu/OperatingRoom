import { Component, OnInit } from '@angular/core';
import { LoginUserService } from 'src/app/service/login-user.service';

@Component({
  selector: 'app-hoom',
  templateUrl: './hoom.component.html',
  styleUrls: ['./hoom.component.css']
})
export class HoomComponent implements OnInit {

  constructor(private loginService:LoginUserService) { }

  ngOnInit(): void {

  }

}
