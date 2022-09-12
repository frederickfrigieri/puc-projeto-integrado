export class UsuarioLogadoModel {
    chaveUsuario: string;
    perfilId: PerfilId;
    login: string;
    logado: boolean;
}

export enum PerfilId {
    parceiro = 1,
    consumidor = 2,
    operador = 3
}