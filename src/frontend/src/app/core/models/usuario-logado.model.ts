export class UsuarioLogadoModel {
    chaveUsuario: string;
    perfilId: PerfilId;
    nome: string;
    email: string;
    logado: boolean;
}

export enum PerfilId {
    parceiro = 1,
    consumidor = 2,
    operador = 3
}