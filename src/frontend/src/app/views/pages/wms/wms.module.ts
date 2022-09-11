import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { NgxMaskModule } from 'ngx-mask';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedComponentsModule } from 'src/app/core/shared-components/shared-components.module';
import { ListagemProdutosComponent } from './listagem-produtos/listagem-produtos.component';
import { AdicionarProdutoComponent } from './adicionar-produto/adicionar-produto.component';
import { ListagemEstoquesComponent } from './listagem-estoques/listagem-estoques.component';
import { AdicionarEstoqueComponent } from './adicionar-estoque/adicionar-estoque.component';
import { WmsComponent } from './wms.component';
import { ListagemParceirosComponent } from '../oms/listagem-parceiros/listagem-parceiros.component';

const routes: Routes = [
  {
    path: 'estoques',
    component: WmsComponent,
    children: [
      {
        path: '',
        component: ListagemEstoquesComponent
      },
      {
        path: 'adicionar',
        component: AdicionarEstoqueComponent
      }
    ]
  },
  {
    path: 'produtos',
    component: WmsComponent,
    children: [
      {
        path: '',
        component: ListagemProdutosComponent
      },
      {
        path: 'novo',
        component: AdicionarProdutoComponent
      },
    ]
  }
]


@NgModule({
  declarations: [
    WmsComponent,
    ListagemEstoquesComponent,
    ListagemProdutosComponent,
    AdicionarEstoqueComponent,
    AdicionarProdutoComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    NgxMaskModule.forRoot({ validation: true }),
    ReactiveFormsModule,
    SharedComponentsModule,
  ]
})
export class WmsModule { }
