import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { UsuarioLogadoModel } from "../models/usuario-logado.model";
import { SessionStorageService } from "./session-storage.service";
import { TokenService } from "./token.service";

@Injectable({ providedIn: 'root' })
export class AuthService {

    static chave = 'DS-202212';
    endpoint = environment.urlAuth;

    constructor(
        private httpClient: HttpClient,
        private sessionStorage: SessionStorageService,
        private tokenService: TokenService
    ) { }

    logar(model: any): Observable<any> {
        return this.httpClient.post<any>(`${this.endpoint}/autenticacao`, model);
    }

    get usuarioLogado(): UsuarioLogadoModel {
        const token = this.sessionStorage.get(AuthService.chave);
        return this.tokenService.decrypt(token);
    }
}
