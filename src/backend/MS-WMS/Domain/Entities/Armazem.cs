using Domain._SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Armazem : Entity, IAggregateRoot
    {
        internal Armazem(string descricao)
        {
            Descricao = descricao;
        }

        public string Descricao { get; private set; }
        public List<Posicao> Posicoes { get; private set; }
        public List<Estoque> Estoques { get; private set; }
        public List<PedidoItem> Itens { get; private set; }

        private Armazem() { }

        public static Armazem Criar(string descricao)
        {
            return new Armazem(descricao);
        }

        public Posicao CadastrarPosicao(int numero, string letra)
        {
            var posicao = new Posicao(numero, letra);

            if (Posicoes == null) Posicoes = new List<Posicao>();

            Posicoes.Add(posicao);

            return posicao;
        }

        public void CadastrarEstoque(
            Guid chaveParceiro,
            Produto produto,
            short quantidade)
        {
            Estoques ??= new List<Estoque>();

            Enumerable.Range(1, quantidade).ToList().ForEach(count =>
            {
                var estoque = new Estoque(chaveParceiro, produto);
                Estoques.Add(estoque);
            });
        }
    }

    public struct AssociarItemPedidoNoEstoqueResponse
    {
        public Guid ChaveEstoque { get; set; }
        public Guid ChavePedido { get; set; }
    }

    public struct AssociarItemPedidoResponse
    {
        public Guid ChavePedido { get; set; }
        public Guid ChaveArmazem { get; set; }
    }

    public struct CadastrarItemResponse
    {
        public Guid ChaveItem { get; set; }
        public Guid ChavePedido { get; set; }
        public Guid ChaveParceiro { get; set; }
    }
}
