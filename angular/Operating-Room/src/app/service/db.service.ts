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
addNewSergery(surgery:Surgery){
  return this.http.post<Surgery>('http://localhost:63703/api/Surgery/AddSurgery',surgery);
}
    getSurgeryFromSpecificDate(today:Date){
      return this.http.get<Surgery[]>('http://localhost:63703/api/Surgery/GetSurgeryFromSpecificDate');
    }
    //ROOM
    getClearRoom(numClass:number){
      return this.http.post<Room[]>("http://localhost:63703/api/Room/GetClearRoom",numClass)
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
