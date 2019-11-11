import { Injectable, OnInit, Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { TestMassage} from '../Models';


@Component({ templateUrl: 'AuthTest.html' })
// tslint:disable-next-line: component-class-suffix
export class AuthTest implements OnInit {
    error: any;
    response: any;
    token: string;
    constructor(private http: HttpClient) {}
    ngOnInit() {
        this.response = this.getTestMassage();

    }
    getTestMassage() {
        const JwtHeader = new HttpHeaders();
        JwtHeader.append('Content-Type', 'application/json');
        JwtHeader.append('Authorization', 'Bearer ' + localStorage.getItem('accsessToken'));
        return this.http.get<any>(`http://localhost:52192/api/test/testvalue`, {headers: JwtHeader});

    }
}
