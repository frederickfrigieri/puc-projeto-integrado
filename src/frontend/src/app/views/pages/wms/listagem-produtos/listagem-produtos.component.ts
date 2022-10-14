import { Component, OnInit } from '@angular/core';
import { Perfil, UsuarioLogadoModel } from 'src/app/core/models/usuario-logado.model';
import { AuthService } from 'src/app/core/services/auth.service';
import { OmsService } from 'src/app/core/services/oms.service';
import { SessionStorageService } from 'src/app/core/services/session-storage.service';
import { TokenService } from 'src/app/core/services/token.service';
import { WmsService } from 'src/app/core/services/wms.service';

@Component({
  selector: 'app-listagem-produtos',
  templateUrl: './listagem-produtos.component.html',
  styleUrls: ['./listagem-produtos.component.scss']
})
export class ListagemProdutosComponent implements OnInit {

  titulo = 'Listagem de Produtos';

  carregando = false;
  colecao: any[] = [];
  usuario: UsuarioLogadoModel;

  constructor(
    private omsService: OmsService,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.carregando = true;
    this.usuario = this.authService.usuarioLogado;

    this.omsService.getProdutos()
      .subscribe(resp => {
        resp.forEach(item => this.colecao.push(item));
        this.carregando = false;
      });
  }

  get exibeBotaoNovoProduto(): boolean {
    return this.usuario.perfil !== 'Operador';
  }

}
