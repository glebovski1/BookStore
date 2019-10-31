import { Injectable, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { TokenResponseModel, RegistrationModel } from 'app/models';
import { resolve } from 'url';
import { environment } from 'environments/environment';

@Injectable({ providedIn: 'root' })
export class RegistrationService {

    constructor(private http: HttpClient) { }

    async registration(user: RegistrationModel) {
        return this.http.post<RegistrationModel>(`${environment.apiUrl}account/register`, user).toPromise();
    }
}
