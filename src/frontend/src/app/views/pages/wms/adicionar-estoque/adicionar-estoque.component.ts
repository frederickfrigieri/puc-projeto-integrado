import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';
import { MessageAlertService } from 'src/app/core/services/message-alert.service';
import { WmsService } from 'src/app/core/services/wms.service';

@Component({
  selector: 'app-adicionar-estoque',
  templateUrl: './adicionar-estoque.component.html',
  styleUrls: ['./adicionar-estoque.component.scss']
})
export class AdicionarEstoqueComponent implements OnInit {

  formGroup: FormGroup;

  armazens: any[] = [];
  produtos: any[] = [
    { id: 1, name: 'Notebook Dell' },
    { id: 2, name: 'Maquina de Lavar' },
    { id: 3, name: 'Ferro para passar roupa' },
  ];


  constructor(
    private formBuilder: FormBuilder,
    private wmsService: WmsService,
    private authService: AuthService,
    private messageService: MessageAlertService,
    private router: Router) { }

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      chaveArmazem: [null, [Validators.required]],
      chaveProduto: [null, [Validators.required]],
      quantidade: [null, [Validators.required, Validators.min(1)]],
      chaveParceiro: [this.authService.usuarioLogado.chaveUsuario, [Validators.required]]
    });

    this.carregarArmazens();
    this.carregarProdutos();
  }

  private carregarProdutos() {
    this.wmsService.getProdutos().subscribe({
      next: (resp) => {
        this.produtos = resp.map(item => {
          return {
            id: item.chave,
            name: `${item.sku} - ${item.descricao}`
          }
        });
      }
    })
  }

  private carregarArmazens() {
    this.wmsService.getArmazens().subscribe({
      next: (resp) => {
        this.armazens = resp.map(item => {
          return {
            id: item.chaveArmazem,
            name: item.descricao
          }
        });
      }
    });
  }

  submit() {
    this.wmsService
      .createEstoque(this.formGroup.value)
      .subscribe(() => {
        this.messageService.success('Estoque cadastrado com sucesso!')
        this.router.navigateByUrl('wms/estoques');
      });
  }
}
