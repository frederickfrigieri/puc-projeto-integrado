import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';
import { WmsService } from 'src/app/core/services/wms.service';

@Component({
  selector: 'app-listagem-estoques',
  templateUrl: './listagem-estoques.component.html',
  styleUrls: ['./listagem-estoques.component.scss']
})
export class ListagemEstoquesComponent implements OnInit {

  titulo = 'Listagem de Estoques';

  constructor(
    private wmsService: WmsService,
    private authService: AuthService
  ) { }

  colecao: any[] = [];

  ngOnInit(): void {
    this.wmsService.getEstoques(this.authService.usuarioLogado.chaveUsuario)
      .subscribe(resp => resp.forEach(item => this.colecao.push(item)));
  }

  get perfil() {
    return this.authService.usuarioLogado.perfil;
  }
}
