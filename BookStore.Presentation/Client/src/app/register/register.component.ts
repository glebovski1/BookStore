import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators, NgForm, FormControl, FormControlDirective } from '@angular/forms';

import { RegistrationService } from 'app/Service';
import { RegistrationModel } from 'app/models';

@Component({ templateUrl: 'register.component.html' })
export class RegisterComponent implements OnInit {
    registerForm: FormGroup;
    loading = false;
    submitted = false;
    error: string;
    userModel: RegistrationModel;

    constructor(
        private formBuilder: FormBuilder,
        private registrationService: RegistrationService
    ) { }

    ngOnInit() {
           this.registerForm = this.formBuilder.group({
           firstName: ['', Validators.required],
           lastName: ['', Validators.required],
           username: ['', Validators.required],
           email: ['', Validators.required],
           password: ['', [Validators.required, Validators.minLength(6)]],
           passwordConfirm: ['', [Validators.required, Validators.minLength(6)]],
       });
   }


    get f() { return this.registerForm.controls; }

    async onSubmit(f: NgForm) {
        this.submitted = true;

        if (this.registerForm.invalid) {
            return;
        }

        this.loading = true;
        if (this.f.password.value === this.f.passwordConfirm.value) {
            this.userModel = new RegistrationModel();
            this.userModel.Email = this.f.email.value;
            this.userModel.FirstName = this.f.firstName.value;
            this.userModel.LastName = this.f.lastName.value;
            this.userModel.UserName = this.f.username.value;
            this.userModel.Password = this.f.password.value;
            this.registrationService.registration(this.userModel);
        }
    }
}

