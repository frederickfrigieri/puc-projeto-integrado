import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";

@Injectable({ providedIn: "root" })
export class WmsService {

    constructor(private httpClient: HttpClient) { };

    createProduto(model: any): Observable<any> {
        const endpoint = `/parceiros/${model.chaveParceiro}/produtos`;
        return this.httpClient.post<any>(endpoint, model);
    }

    getProdutos(chaveParceiro: string): Observable<any[]> {
        const endpoint = `/parceiros/${chaveParceiro}/produtos`;
        return this.httpClient.get<any[]>(endpoint);
    }

    setEstoque(model: any): Observable<any> {
        return of({});
    }

    getEstoques(chaveParceiro: string): Observable<any[]> {
        return of([
            {
                id: 1,
                produto: 'TV Samsung',
                quantidade: 10,
                posicao: 'Rua A - Prateleira 3'
            },
            {
                id: 1,
                produto: 'Iphone',
                quantidade: 3,
                posicao: 'Rua A - Prateleira 1'
            },
            {
                id: 1,
                produto: 'Notebook Dell',
                quantidade: 1,
                posicao: 'Rua A - Prateleira 2'
            }
        ]);
    }
}