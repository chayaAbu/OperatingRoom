import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Surgery } from '../model/Surgery';

@Injectable({
  providedIn: 'root'
})
export class DbService {

  constructor(private http:HttpClient) {  }
    getSurgeryFromCurrentDate(){
      return this.http.get<Surgery[]>('http://localhost:63703/api/Surgery/GetSurgeryFromCurrentDate');
    }

    getSurgeryFromSpecificDate(today:Date){
      return this.http.get<Surgery[]>('http://localhost:63703/api/Surgery/GetSurgeryFromSpecificDate');
    }
 
}
