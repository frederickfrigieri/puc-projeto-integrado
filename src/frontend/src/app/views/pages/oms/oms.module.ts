import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListagemPedidosComponent } from './listagem-pedidos/listagem-pedidos.component';
import { CadastrarPedidoComponent } from './cadastrar-pedido/cadastrar-pedido.component';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedComponentsModule } from 'src/app/core/shared-components/shared-components.module';
import { NgxMaskModule } from 'ngx-mask';
import { OmsComponent } from './oms.component';
import { ListagemParceirosComponent } from './listagem-parceiros/listagem-parceiros.component';

const routes: Routes = [
  {
    path: 'pedidos',
    component: OmsComponent,
    children: [
      {
        path: '',
        component: ListagemPedidosComponent
      },
      {
        path: 'novo',
        component: CadastrarPedidoComponent
      }
    ]
  },
  {
    path: 'parceiros',
    component: OmsComponent,
    children: [
      {
        path: '',
        component: ListagemParceirosComponent
      }
    ]
  }
]


@NgModule({
  declarations: [
    OmsComponent, 
    CadastrarPedidoComponent, 
    ListagemParceirosComponent,
    ListagemPedidosComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    NgxMaskModule.forRoot({ validation: true }),
    ReactiveFormsModule,
    SharedComponentsModule
  ]
})
export class OmsModule { }
