import { Component, OnInit } from '@angular/core';
import { WmsService } from 'src/app/core/services/wms.service';

@Component({
  selector: 'app-listagem-estoques',
  templateUrl: './listagem-estoques.component.html',
  styleUrls: ['./listagem-estoques.component.scss']
})
export class ListagemEstoquesComponent implements OnInit {

  titulo = 'Listagem de Estoques';

  constructor(private wmsService: WmsService) { }

  colecao: any[] = [];

  ngOnInit(): void {
    this.wmsService.getEstoques("")
      .subscribe(resp => resp.forEach(item => this.colecao.push(item)));
  }
}
