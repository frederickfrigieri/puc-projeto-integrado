export class UsuarioLogadoModel {
    chaveUsuario: string;
    perfil: Perfil;
    login: string;
    logado: boolean;
}

export enum Perfil {
    Admin,
    operador,
    Parceiro
}