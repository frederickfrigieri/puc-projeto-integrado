import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';
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

  colecao: any[] = [];

  constructor(
    private wmsService: WmsService,
    private tokenService: TokenService,
    private sessionStorage: SessionStorageService
  ) { }

  ngOnInit(): void {
    const usuario = this.tokenService
      .decrypt(this.sessionStorage.get(AuthService.chave));

    this.wmsService.getProdutos(usuario.chaveUsuario).subscribe(resp => {
      resp.forEach(item => this.colecao.push(item));
    });
  }

}
