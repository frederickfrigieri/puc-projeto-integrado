import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';
import { MessageAlertService } from 'src/app/core/services/message-alert.service';
import { SessionStorageService } from 'src/app/core/services/session-storage.service';
import { TokenService } from 'src/app/core/services/token.service';
import { WmsService } from 'src/app/core/services/wms.service';

@Component({
  selector: 'app-adicionar-produto',
  templateUrl: './adicionar-produto.component.html',
  styleUrls: ['./adicionar-produto.component.scss']
})
export class AdicionarProdutoComponent implements OnInit {

  formGroup: FormGroup

  constructor(
    private formBuilder: FormBuilder,
    private wmsService: WmsService,
    private sessionStorage: SessionStorageService,
    private tokenService: TokenService,
    private messageAlert: MessageAlertService,
    private router: Router) { }

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      descricao: [null, [Validators.required]],
      sku: [null, [Validators.required]],
      chaveParceiro: [null, [Validators.required]]
    });

    this.formGroup.get('chaveParceiro')?.patchValue(this.chaveParceiro);
  }

  get chaveParceiro() {
    const token = this.sessionStorage.get(AuthService.chave);
    const usuario = this.tokenService.decrypt(token);

    return usuario.chaveUsuario;
  }

  submit() {
    if (this.formGroup.invalid) {
      this.messageAlert.erroFormulario();
    } else {
      this.wmsService
        .createProduto(this.formGroup.value)
        .subscribe(resp => {
          this.messageAlert.success('Produto Cadastrado', 'Sucesso!');
          this.router.navigateByUrl('/wms/produtos');
        });
    }
  }
}
