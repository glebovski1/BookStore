import { Injectable, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { TokenResponseModel, RegistrationModel } from '../models';
import { resolve } from 'url';

@Injectable({ providedIn: 'root' })
export class RegistrationService {

    constructor(private http: HttpClient) { }

    async registration(user: RegistrationModel) {
        return this.http.post<RegistrationModel>(`http://localhost:52192/api/account/register`, user).toPromise();
    }
}
