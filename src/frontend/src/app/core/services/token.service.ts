import { Injectable } from "@angular/core";
import { UsuarioLogadoModel } from "../models/usuario-logado.model";
import { SessionStorageService } from "./session-storage.service";

@Injectable({ providedIn: 'root' })
export class TokenService {


    constructor(private sessionStorage: SessionStorageService) { }

    decrypt(token: string): any {

        var key = this.sessionStorage.get(token);

        if (!key) return null;

        return <UsuarioLogadoModel>{
            chaveUsuario: '',
            email: '',
            logado: true,
            nome: ''
        }
    }

}