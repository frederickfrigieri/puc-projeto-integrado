import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { environment } from "src/environments/environment";
import { UsuarioLogadoModel } from "../models/usuario-logado.model";

@Injectable({ providedIn: 'root' })
export class AuthService {

    usuarioLogado: UsuarioLogadoModel;

    static chave = 'DS-202212';

    constructor(private httpClient: HttpClient) { }

    logar(model: any): Observable<any> {
        return this.httpClient.post<any>(`/login`, model);
    }
}
