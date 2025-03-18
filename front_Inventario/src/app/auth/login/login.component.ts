import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

// Elements
import { InputComponent } from '../../elements/input/input.component';
import { ButtonComponent } from '../../elements/button/button.component';
import { Commons } from '../../utils/commons';

@Component({
  selector: 'app-login',
  imports: [InputComponent, ButtonComponent, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  loginForm: FormGroup = new FormGroup({
    usr: new FormControl('', [Validators.required]),
    pwd: new FormControl('', [Validators.required]),
  });

  constructor(private cmm: Commons) {}

  login() {
    const formValue = this.loginForm.value;
    const params = {
      Username: formValue.usr,
      Password: formValue.password,
    };

    this.cmm.postReq('Auth/login', params).subscribe((rs: any) => {
      console.log('LOGIN RESPONSE', rs);
    });
  }

  getErrorMessage(controlName: string): string {
    const control = this.loginForm.get(controlName);
    if (!control?.errors || !control.touched) return '';

    if (controlName === 'usr') {
      if (control.errors['required']) return 'El usuario es requerido';
    }

    if (controlName === 'pwd') {
      if (control.errors['required']) return 'La contraseña es requerida';
    }

    return '';
  }
}
