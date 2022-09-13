import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';
import { MessageAlertService } from 'src/app/core/services/message-alert.service';
import { OmsService } from 'src/app/core/services/oms.service';
import { SessionStorageService } from 'src/app/core/services/session-storage.service';
import { TokenService } from 'src/app/core/services/token.service';
import { WmsService } from 'src/app/core/services/wms.service';

@Component({
  selector: 'app-cadastrar-pedido',
  templateUrl: './cadastrar-pedido.component.html',
  styleUrls: ['./cadastrar-pedido.component.scss']
})
export class CadastrarPedidoComponent implements OnInit {

  constructor(
    private formBuilder: FormBuilder,
    private omsService: OmsService,
    private wmsService: WmsService,
    private tokenService: TokenService,
    private sessionStorage: SessionStorageService,
    private messageAlert: MessageAlertService,
    private router: Router) { }

  produtos: any[] = [];

  private token: any;
  private usuario: any;

  formGroup: FormGroup;

  ngOnInit(): void {
    this.token = this.sessionStorage.get(AuthService.chave);
    this.usuario = this.tokenService.decrypt(this.token);

    this.criarFormGroup();
    this.carregarProdutos();
  }

  private criarFormGroup() {
    this.formGroup = this.formBuilder.group({
      nomeCompleto: [null, [Validators.required]],
      numero: [null, [Validators.required]],
      valor: [null, [Validators.required]],
      itens: this.formBuilder.array([]),
      chaveParceiro: [null, [Validators.required]]
    });
    this.addItem();
    this.formGroup.controls['chaveParceiro'].patchValue(this.usuario.chaveUsuario);
  }


  private carregarProdutos() {
    this.wmsService.getProdutos(this.usuario.chaveUsuario).subscribe(resp => {
      this.produtos = resp.map(item => {
        return {
          id: item.chave,
          name: item.descricao
        }
      });
    });
  }

  get itens() {
    return this.formGroup.get("itens") as FormArray;
  }

  addItem() {
    const itemForm = this.formBuilder.group({
      chaveProduto: [null, Validators.required],
      quantidade: [null, Validators.required]
    });

    this.itens.push(itemForm);
  }

  submit() {
    console.table(this.formGroup.value);
    this.omsService.sendPedido(this.formGroup.value).subscribe(() => {
      this.messageAlert.success('Pedido cadastrado', 'Sucesso!!');
      this.router.navigateByUrl('/oms/pedidos');
    });
  }

}
