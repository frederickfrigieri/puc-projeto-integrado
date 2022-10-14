export class UsuarioLogadoModel {
    chaveUsuario: string;
    perfil: string;
    login: string;
    logado: boolean;
}

export enum Perfil {
    Admin,
    Operador,
    Parceiro
}