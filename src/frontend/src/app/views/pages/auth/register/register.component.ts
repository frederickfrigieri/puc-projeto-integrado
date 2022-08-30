import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  constructor(private router: Router, private formBuilder: FormBuilder) { }

  formGroup: FormGroup;

  ngOnInit(): void {
    this.createFormGroup();
  }

  private createFormGroup() {
    this.formGroup = this.formBuilder.group({
      'razaoSocial': [null, [Validators.required]],
      'cnpj': [null, [Validators.required, Validators.minLength(14), Validators.maxLength(14)]],
      'nome': [null, [Validators.required]],
      'email': [null, [Validators.required, Validators.email]],
      'chaveBling': [null, [Validators.required]],
      'senha': [null, [Validators.required, Validators.minLength(6), Validators.maxLength(10)]],
      'senhaConfirmacao': [null, [Validators.required, Validators.minLength(6), Validators.maxLength(10)]],
    });
  }

  onRegister(e: Event) {
    e.preventDefault();
    localStorage.setItem('isLoggedin', 'true');
    if (localStorage.getItem('isLoggedin')) {
      this.router.navigate(['/']);
    }
  }

}
