import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'environments/environment';
import { TokenResponseModel, RefreshTokenModel } from 'app/models';


@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    error: any;
    refreshRequest: RefreshTokenModel;
    tokensRequest: TokenResponseModel;
    constructor(private http: HttpClient) {}
    login(email: string, password: string) {
     this.http.post<TokenResponseModel>(`${environment.apiUrl}account/loggin`, {email, password}).subscribe(
        (data: TokenResponseModel) => {
          localStorage.setItem('role', data.role);
          localStorage.setItem('accessToken', data.accessToken);
          localStorage.setItem('refreshToken', data.refreshToken);
          localStorage.setItem('email', email);
          localStorage.setItem('id', data.id.toString());
         },
        (error) => { 
          this.error = error.Massage; } );
    }
    logOut() {
        localStorage.clear();
    }
    getAccesToken(): string {
      return localStorage.getItem('accessToken');
    }
    getRefrershToken(): string {
      return localStorage.getItem('refreshToken');
    }
    getHttpOptionsWithAccessToken() {
      const httpOptions = {
        headers: new HttpHeaders({Authorization: `Bearer ${this.getAccesToken()}` })
      };
      return httpOptions;
    }
    getHttpOptionsWithRefreshToken(): any {
      const httpOptions = {
        headers: new HttpHeaders({Authorization: `Bearer ${this.getRefrershToken()}` })
      };
      return httpOptions;
    }
    getRole(): string {
      return localStorage.getItem('role');
    }
    getId(): number {
      return Number(localStorage.getItem('id'));
    }
    refreshToken() {
      this.refreshRequest = new RefreshTokenModel();
      this.refreshRequest.LoginProvider = '';
      this.refreshRequest.RefreshTokenFromClient = this.getRefrershToken();
      this.refreshRequest.email = localStorage.getItem('email');
      this.http.post<TokenResponseModel>(`${environment.apiUrl}account/jwtrefresh`, this.refreshRequest).subscribe(
        (data: TokenResponseModel) => {
          localStorage.setItem('accessToken', data.accessToken);
          localStorage.setItem('refreshToken', data.refreshToken);
        },
        (error) => {this.error = error.Massage; }
      );
    }
}

