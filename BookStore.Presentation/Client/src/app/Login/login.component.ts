import { Component, OnInit } from '@angular/core';
import { AuthenticationService} from 'app/Service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({ templateUrl: 'login.component.html' })
export class LoginComponent implements OnInit {
    loginForm: FormGroup;
    constructor(private authenticationService: AuthenticationService,  private formBuilder: FormBuilder, ) {}
    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required]
        });
    }

    get f() { return this.loginForm.controls; }
    onSubmit() {
            this.authenticationService.login(this.f.username.value, this.f.password.value);
    }
}