import { Component } from '@angular/core';

// Elements
import { InputComponent } from '../../elements/input/input.component';

@Component({
  selector: 'app-login',
  imports: [InputComponent],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {}
