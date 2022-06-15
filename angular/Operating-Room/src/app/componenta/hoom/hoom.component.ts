import { Component, OnInit } from '@angular/core';
import { DbService } from 'src/app/service/db.service';
import { LoginUserService } from 'src/app/service/login-user.service';

@Component({
  selector: 'app-hoom',
  templateUrl: './hoom.component.html',
  styleUrls: ['./hoom.component.css']
})
export class HoomComponent implements OnInit {
  userName?:string;

  constructor(private db: DbService) {
    this.userName=db.logUserName;
   }

  ngOnInit(): void {

  }

}
