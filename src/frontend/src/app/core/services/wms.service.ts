import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { environment } from "src/environments/environment";

@Injectable({ providedIn: "root" })
export class WmsService {

    constructor(private httpClient: HttpClient) { };

    endpoint = environment.urlWms;

    createProduto(model: any): Observable<any> {
        const endpoint = `${this.endpoint}/parceiros/${model.chaveParceiro}/produtos`;
        return this.httpClient.post<any>(endpoint, model);
    }

    createEstoque(model: any): Observable<any> {
        const endpoint = `${this.endpoint}/parceiros/${model.chaveParceiro}/estoques`;
        return this.httpClient.post<any>(endpoint, model);
    }


    getProdutos(): Observable<any[]> {
        const endpoint = `${this.endpoint}/parceiros/produtos`;
        return this.httpClient.get<any[]>(endpoint);
    }

    getArmazens(): Observable<any[]> {
        const endpoint = `${this.endpoint}/armazens`;
        return this.httpClient.get<any[]>(endpoint);
    }

    getEstoques(chaveParceiro: string): Observable<any[]> {
        const endpoint = `${this.endpoint}/parceiros/${chaveParceiro}/estoques`;
        return this.httpClient.get<any[]>(endpoint);
    }
}