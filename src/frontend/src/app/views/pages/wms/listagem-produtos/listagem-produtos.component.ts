import { Component, OnInit } from '@angular/core';
import { WmsService } from 'src/app/core/services/wms.service';

@Component({
  selector: 'app-listagem-produtos',
  templateUrl: './listagem-produtos.component.html',
  styleUrls: ['./listagem-produtos.component.scss']
})
export class ListagemProdutosComponent implements OnInit {

  titulo = 'Listagem de Produtos';

  colecao: any[] = [];

  constructor(private wmsService: WmsService) { }

  ngOnInit(): void {
    this.wmsService.getProdutos("").subscribe(resp => {
      resp.forEach(item => this.colecao.push(item));
    });
  }

}
