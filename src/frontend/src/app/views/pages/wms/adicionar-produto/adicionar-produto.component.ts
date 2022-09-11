import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { WmsService } from 'src/app/core/services/wms.service';

@Component({
  selector: 'app-adicionar-produto',
  templateUrl: './adicionar-produto.component.html',
  styleUrls: ['./adicionar-produto.component.scss']
})
export class AdicionarProdutoComponent implements OnInit {

  formGroup: FormGroup

  constructor(
    private formBuilder: FormBuilder,
    private wmsService: WmsService) { }

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      nome: [null, [Validators.required]],
      sku: [null, [Validators.required]],
    });
  }

  submit() {
    this.wmsService
      .createProduto(this.formGroup.value)
      .subscribe(resp => { });
  }
}
