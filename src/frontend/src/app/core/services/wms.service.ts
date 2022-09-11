import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";

@Injectable({ providedIn: "root" })
export class WmsService {

    constructor() { };

    createProduto(model: any): Observable<any> {
        return of({});
    }

    getProdutos(chaveParceiro: string): Observable<any[]> {
        return of([
            {
                id: 1,
                descricao: 'TV Samsung',
                sku: 'TVS-1020',
                chave: '366498TR-36498698AB'
            },
            {
                id: 2,
                descricao: 'Iphone 10',
                sku: 'IPH-3020',
                chave: '36649T8R-3649X8698B'
            },
            {
                id: 3,
                descricao: 'Notebook Dell',
                sku: 'DLL-3440',
                chave: '366498E9-36498698XX'
            }
        ]);
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