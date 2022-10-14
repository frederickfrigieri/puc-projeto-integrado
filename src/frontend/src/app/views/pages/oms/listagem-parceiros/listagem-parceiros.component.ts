import { Component, OnInit } from '@angular/core';
import { OmsService } from 'src/app/core/services/oms.service';

@Component({
  selector: 'app-listagem-parceiros',
  templateUrl: './listagem-parceiros.component.html',
  styleUrls: ['./listagem-parceiros.component.scss']
})
export class ListagemParceirosComponent implements OnInit {

  titulo = 'Parceiros'

  colecao: any[] = [];

  constructor(private omsService: OmsService) { }

  ngOnInit(): void {
    this.omsService.getParceiros()
      .subscribe(resp => {
        resp.forEach(item => this.colecao.push(item))
      });
  }
}
