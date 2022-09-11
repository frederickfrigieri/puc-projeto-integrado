import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UsuarioLogadoModel } from 'src/app/core/models/usuario-logado.model';
import { AuthService } from 'src/app/core/services/auth.service';
import { MessageAlertService } from 'src/app/core/services/message-alert.service';
import { OmsService } from 'src/app/core/services/oms.service';
import { TokenService } from 'src/app/core/services/token.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private omsService: OmsService,
    private messageAlertService: MessageAlertService) { }

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

    const model = this.formGroup.value;

    this.omsService
      .createParceiro(model)
      .subscribe(resp => {
        this.formGroup.reset();
        this.messageAlertService.success('Parceiro cadastrado', 'Sucesso!!');
        this.router.navigate(['/']);
      });
  }
}
