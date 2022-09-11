import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OmsService } from 'src/app/core/services/oms.service';

@Component({
  selector: 'app-cadastrar-pedido',
  templateUrl: './cadastrar-pedido.component.html',
  styleUrls: ['./cadastrar-pedido.component.scss']
})
export class CadastrarPedidoComponent implements OnInit {

  constructor(
    private formBuilder: FormBuilder,
    private omsService: OmsService) { }

  produtos = [{ id: 1, name: 'Totmate' }];

  formGroup: FormGroup;

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      nome: [null, [Validators.required]],
      numero: [null, [Validators.required]],
      valor: [null, [Validators.required]],
      itens: this.formBuilder.array([])
    });
    this.addItem();
  }

  get itens() {
    return this.formGroup.get("itens") as FormArray;
  }

  addItem() {
    const itemForm = this.formBuilder.group({
      chaveProduto: [null, Validators.required],
      quantidade: [null, Validators.required]
    });

    this.itens.push(itemForm);
  }

  submit() {
    console.table(this.formGroup.value);
    this.omsService.sendPedido(this.formGroup.value);
  }

}
