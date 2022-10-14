import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OmsService {

  constructor(private httpClient: HttpClient) { }

  endpoint = environment.urlOms;

  getPedidos(): Observable<any[]> {
    return this.httpClient.get<any[]>(`${this.endpoint}/parceiros/pedidos`);
  }

  sendPedido(model: any): Observable<any> {
    const endpoint = `${this.endpoint}/parceiros/${model.chaveParceiro}/pedidos`;
    return this.httpClient.post<any>(endpoint, model);
  }

  createParceiro(model: any): Observable<any> {
    return this.httpClient.post(`${this.endpoint}/parceiros`, model);
  }

  getParceiros(): Observable<any[]> {
    return this.httpClient.get<any[]>(`${this.endpoint}/parceiros`);
  }

  getProdutos(): Observable<any[]> {
    const endpoint = `${this.endpoint}/parceiros/produtos`;
    return this.httpClient.get<any[]>(endpoint);
  }
}
