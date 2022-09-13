import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OmsService {

  constructor(private httpClient: HttpClient) { }

  getPedidos(chaveParceiro: string): Observable<any[]> {
    const endpoint = `/parceiros/${chaveParceiro}/pedidos`;

    return this.httpClient.get<any[]>(endpoint);

  }

  sendPedido(model: any): Observable<any> {
    const endpoint = `/parceiros/${model.chaveParceiro}/pedidos`;

    return this.httpClient.post<any>(endpoint, model);
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

  getProdutos(chaveParceiro: string): Observable<any[]> {
    const endpoint = `/parceiros/${chaveParceiro}/produtos`;

    return this.httpClient.get<any[]>(endpoint);
  }
}
