import { Injectable } from "@angular/core";
import { UsuarioLogadoModel } from "../models/usuario-logado.model";
import jwt_decode from "jwt-decode";
import { Observable, of } from "rxjs";

@Injectable({ providedIn: 'root' })
export class TokenService {

    constructor() { }

    decrypt(token: string): UsuarioLogadoModel {
        var jsonToken = jwt_decode<any>(token);

        var usuario = <UsuarioLogadoModel>{
            chaveUsuario: jsonToken['nameid'],
            logado: true,
            login: jsonToken.actort
        };

        return usuario;
    }
}