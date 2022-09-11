import { Component, OnInit } from '@angular/core';
import { OmsService } from 'src/app/core/services/oms.service';

@Component({
  selector: 'app-listagem-pedidos',
  templateUrl: './listagem-pedidos.component.html',
  styleUrls: ['./listagem-pedidos.component.scss']
})
export class ListagemPedidosComponent implements OnInit {

  constructor(private omsService: OmsService) { }

  colecaoPedidos: any[] = [];

  ngOnInit(): void {
    this.omsService
      .getPedidos("")
      .subscribe(resp => {
        resp.forEach(item => this.colecaoPedidos.push(item));
      });
  }

}
