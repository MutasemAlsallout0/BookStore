import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ILoginRequest } from '../Interfaces/ILoginRequest ';
import { IRegisterRequest } from '../Interfaces/IRegisterRequest ';
import { IAuthResponse } from '../Interfaces/IAuthResponse';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseURL = environment.baseUrl + '/api/auth';
  constructor(private httpClient: HttpClient) { }
  
  registerUser(userForRegister: IRegisterRequest) {
    return this.httpClient.post<IAuthResponse>(
      this.baseURL + '/register',
      userForRegister
    );
  }

  isAuthenticated() {
    const token = localStorage.getItem('token');
    if (!token) return false;

    const expiration = localStorage.getItem('token-expiration')!;
    const expirationDate = new Date(expiration);

    if (expirationDate <= new Date()) {
      this.logout();
      return false;
    }

    return true;
  }

  getFieldFromJWT(field: string) {
    const token = localStorage.getItem('token');
    if (!token) return '';
    const dataToken = JSON.parse(atob(token.split('.')[1]));
    return dataToken[field];
  }

  isUserAdmin() {
    const role = this.getFieldFromJWT(
      'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
    );

    return role === 'Admin';
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('token-expiration');
  }

  loginUser(userForAuth: ILoginRequest) {
    return this.httpClient.post<IAuthResponse>(
      this.baseURL + '/login',
      userForAuth
    );
  }

  saveToken(authResponse: IAuthResponse) {
    localStorage.setItem('token', authResponse.token);
    localStorage.setItem(
      'token-expiration',
      authResponse.expiration.toString()
    );
  }

  getToken() {
    return localStorage.getItem('token');
  }
}
