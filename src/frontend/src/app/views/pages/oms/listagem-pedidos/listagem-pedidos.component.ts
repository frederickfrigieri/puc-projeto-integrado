import { Component, OnInit } from '@angular/core';
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
    private sessionStorage: SessionStorageService,
    private token: TokenService
  ) { }

  colecao: any[] = [];
  carregando = false;
  usuarioLogado: any;

  ngOnInit(): void {

    const token = this.sessionStorage.get(AuthService.chave);
    this.usuarioLogado = this.token.decrypt(token);

    this.carregando = true;
    this.omsService
      .getPedidos(this.usuarioLogado.chaveUsuario)
      .subscribe(resp => {
        console.table(resp);
        resp.forEach(item => this.colecao.push(item));
        this.carregando = false;
      });
  }
}
