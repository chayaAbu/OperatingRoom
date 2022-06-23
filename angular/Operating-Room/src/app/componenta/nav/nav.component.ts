import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from 'src/app/model/Login';
import { DbService } from 'src/app/service/db.service';
import { LoginUserService } from 'src/app/service/login-user.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private loginService:LoginUserService,private db:DbService,private route:Router) {
    this.myUser=loginService.isLogin
    console.log("nav");
    
    console.log(this.myUser!=undefined);
   }
  myUser:Login|undefined;
  ngOnInit(): void {
  }
addUser(){
  if(this.db.logUserName==null)
  alert("youre not logged to the system")
  else{
 this.route.navigate(['regis'])
}}

addSurgery(){
  if(this.db.logUserName==null)
  alert("youre not logged to the system")
  else{
 this.route.navigate(['surg'])
}}


addRoom(){
  if(this.db.logUserName==null)
  alert("youre not logged to the system")
  else{
 this.route.navigate(['room'])
}}


addDevice(){
  if(this.db.logUserName==null)
  alert("youre not logged to the system")
  else{
 this.route.navigate(['device'])
}}


addScheduling(){
  if(this.db.logUserName==null)
  alert("youre not logged to the system")
  else{
 this.route.navigate(['scheduling'])
}}


}
