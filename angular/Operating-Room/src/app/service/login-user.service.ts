import { Injectable } from '@angular/core';
import { Login } from '../model/Login';

@Injectable({
  providedIn: 'root'
})
export class LoginUserService {
  loginOnce = false;

  isLogin: Login | undefined = undefined
  constructor() { }


}
