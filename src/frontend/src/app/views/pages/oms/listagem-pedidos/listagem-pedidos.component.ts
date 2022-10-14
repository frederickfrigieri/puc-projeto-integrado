import { Component, OnInit } from '@angular/core';
import { UsuarioLogadoModel } from 'src/app/core/models/usuario-logado.model';
import { AuthService } from 'src/app/core/services/auth.service';
import { OmsService } from 'src/app/core/services/oms.service';
import { SessionStorageService } from 'src/app/core/services/session-storage.service';
import { TokenService } from 'src/app/core/services/token.service';

@Component({
  selector: 'app-listagem-pedidos',
  templateUrl: './listagem-pedidos.component.html',
  styleUrls: ['./listagem-pedidos.component.scss']
})
export class ListagemPedidosComponent implements OnInit {

  constructor(
    private omsService: OmsService,
    private authService: AuthService
  ) { }

  colecao: any[] = [];
  carregando = false;
  usuarioLogado: any;

  ngOnInit(): void {
    this.carregando = true;
    this.omsService
      .getPedidos()
      .subscribe({
        next: (resp) => {
          resp.forEach(item => this.colecao.push(item));
          this.carregando = false;
        },
        complete: () => {
          this.carregando = false;
        }
      })
  }

  get exibeBotaoNovoPedido(): boolean {
    return this.authService.usuarioLogado.perfil != 'Operador';
  }
}
