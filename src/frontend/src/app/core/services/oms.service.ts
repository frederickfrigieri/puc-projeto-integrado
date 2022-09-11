import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OmsService {

  constructor() { }

  getPedidos(chaveParceiro: string): Observable<any[]> {
    return of([
      {
        "cliente": "Teodora",
        "produto": "Boneca da Barbie",
        "dataPedido": "20/06/2022",
        "statusPedido": "Aguardando Despacho",
        "armazem": "Armazem Zona Sul"
      },
      {
        "cliente": "Milka",
        "produto": "Osso para cachorro",
        "dataPedido": "10/12/2021",
        "statusPedido": "Aguardando Despacho",
        "armazem": "Armazem Zona Oeste"
      },
      {
        "cliente": "Fred",
        "produto": "TV Samsung",
        "dataPedido": "20/01/2022",
        "statusPedido": "Pendente Armazém",
        "armazem": ""
      },
      {
        "cliente": "Lola",
        "produto": "Comedouro",
        "dataPedido": "20/11/2021",
        "statusPedido": "Pendente Estoque",
        "armazem": "Armazem Zona Leste"
      }
    ]);
  }

  sendPedido(model: any): Observable<any> {
    return of({});
  }

  detailsPedido(chavePedido: string): Observable<any> {
    return of({});
  }

  createParceiro(model: any): Observable<any> {
    return of({});
  }

  getParceiros(): Observable<any[]> {
    return of([
      {
        id: 1,
        razaoSocial: 'F. F. Frigieri Informática',
        cnpj: '18.311.884/0001-60',
        chave: '358995BR-335787E'
      },
      {
        id: 2,
        razaoSocial: 'Fábrica de Software',
        cnpj: '18.314.834/0006-55',
        chave: '359795BR-335787E'
      }
    ]);
  }

  getParceiro(chaveParceiro: string): Observable<any> {
    return of({});
  }
}
