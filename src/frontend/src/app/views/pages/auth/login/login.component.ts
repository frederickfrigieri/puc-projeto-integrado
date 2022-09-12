import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';
import { MessageAlertService } from 'src/app/core/services/message-alert.service';
import { SessionStorageService } from 'src/app/core/services/session-storage.service';
import { TokenService } from 'src/app/core/services/token.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  returnUrl: any;

  formGroup: FormGroup;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService,
    private sessionStorageService: SessionStorageService,
    private tokenService: TokenService,
    private fb: FormBuilder,
    private mensagemAlert: MessageAlertService,
  ) { }

  ngOnInit(): void {

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/dashboard';
    this.formGroup = this.fb.group({
      login: [null, [Validators.required]],
      password: [null, [Validators.required]],
    });

    const token = this.sessionStorageService.get(AuthService.chave);
    const usuarioLogado = this.tokenService.decrypt(token);

    if (usuarioLogado && usuarioLogado.logado) {
      this.router.navigate(['/dashboard']);
      return;
    }
  }

  onLoggedin(e: Event) {
    e.preventDefault();

    if (this.formGroup.valid) {
      this.authService.logar(this.formGroup.value).subscribe(resp => {
        this.sessionStorageService.add(AuthService.chave, resp.token);
        var usuarioLogado = this.tokenService.decrypt(resp.token);

        if (usuarioLogado && usuarioLogado.logado) {
          this.router.navigate([this.returnUrl]);
        } else {
          this.mensagemAlert.error('Problema para autenticar o usuário!');
        }
      });
    } else {
      this.mensagemAlert.formularioInvalido();
    }
  }

  onCreateCustomer() {
    this.router.navigate(['/auth/register']);
  }
}
