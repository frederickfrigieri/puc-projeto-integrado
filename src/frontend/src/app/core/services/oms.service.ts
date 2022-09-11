import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OmsService {

  constructor(private httpClient: HttpClient) { }

  // private endpoint = environment.urlOms + '/api';

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
    return this.httpClient.post(`/parceiros`, model);
  }

  getParceiros(): Observable<any[]> {
    return this.httpClient.get<any[]>(`/parceiros`);
  }

  getParceiro(chaveParceiro: string): Observable<any> {
    return of({});
  }
}
