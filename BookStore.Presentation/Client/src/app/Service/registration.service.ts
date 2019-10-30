import { Injectable, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { TokenResponseModel, RegistrationModel } from '../models';
import { resolve } from 'url';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class RegistrationService {

    constructor(private http: HttpClient) { }

    async registration(user: RegistrationModel) {
        return this.http.post<RegistrationModel>(`${environment.apiUrl}account/register`, user).toPromise();
    }
}
