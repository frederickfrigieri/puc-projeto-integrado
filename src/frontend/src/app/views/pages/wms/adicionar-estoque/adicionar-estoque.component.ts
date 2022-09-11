import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { WmsService } from 'src/app/core/services/wms.service';

@Component({
  selector: 'app-adicionar-estoque',
  templateUrl: './adicionar-estoque.component.html',
  styleUrls: ['./adicionar-estoque.component.scss']
})
export class AdicionarEstoqueComponent implements OnInit {

  formGroup: FormGroup;

  armazens: any[] = [
    { id: 1, name: 'GLP SP ZS' },
    { id: 2, name: 'GLP SP ZN' },
    { id: 3, name: 'GLP RJ ZO' }
  ];

  parceiros: any[] = [
    { id: 1, name: 'Loja do Zezinho' }
  ];

  produtos: any[] = [
    { id: 1, name: 'Notebook Dell' },
    { id: 2, name: 'Maquina de Lavar' },
    { id: 3, name: 'Ferro para passar roupa' },
  ];


  constructor(
    private formBuilder: FormBuilder,
    private wmsService: WmsService) { }

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      chaveProduto: [null, [Validators.required]],
      chaveArmazem: [null, [Validators.required]],
      chaveParceiro: [null, [Validators.required]],
      quantidade: [null, [Validators.required]]
    });
  }

  submit() {
    this.wmsService
      .createProduto(this.formGroup.value)
      .subscribe(resp => { });
  }

}
