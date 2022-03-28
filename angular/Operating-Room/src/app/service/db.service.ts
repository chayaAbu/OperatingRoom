import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login } from '../model/Login';
import { Register } from '../model/Register';
import { Room } from '../model/Room';
import { Surgery } from '../model/Surgery';

@Injectable({
  providedIn: 'root'
})
export class DbService {

  constructor(private http:HttpClient) {  }
  //SURGERY
    getSurgeryFromCurrentDate(){
      return this.http.get<Surgery[]>('http://localhost:63703/api/Surgery/GetSurgeryFromCurrentDate');
    }

    getSurgeryFromSpecificDate(today:Date){
      return this.http.get<Surgery[]>('http://localhost:63703/api/Surgery/GetSurgeryFromSpecificDate');
    }
    //ROOM
    getClearRoom(){
      return this.http.get<Room[]>()
    }
  //REGISTER
    registerNewUser(register:Register):Observable<Register>{
      return this.http.post<Register>("http://localhost:63703/api/User/RegisterUser",register)

    }
    //LOGIN
    loginUser(login:Login):Observable<Login>{
      return this.http.post<Login>("http://localhost:63703/api/User/LoginUser",login)
    }
 
}
