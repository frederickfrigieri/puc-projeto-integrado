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
        public List<ProdutoEntity> Produtos { get; private set; }
        public List<Estoque> Estoques { get; private set; }
        public List<ItemPedidoEntity> Itens { get; private set; }

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

        public Estoque[] CadastrarEstoque(Guid chaveParceiro, Guid chaveProduto, byte quantidade)
        {
            var produto = Produtos
                .Where(x => x.Chave == chaveParceiro && x.Chave == chaveProduto)
                .Single();

            var estoquesCadastrado = new List<Estoque>();

            Enumerable.Range(1, quantidade).ToList().ForEach(count =>
            {
                var estoque = new Estoque(chaveParceiro, this, produto);

                estoquesCadastrado.Add(estoque);
                Estoques.Add(estoque);
            });

            return estoquesCadastrado.ToArray();
        }

        public CadastrarItemResponse CadastrarItem(
            int quantidade,
            ProdutoEntity produto,
            Guid chavePedido,
            Guid chaveParceiro)
        {
            var item = new ItemPedidoEntity(quantidade, produto, chavePedido, chaveParceiro);

            if (Itens == null) Itens = new List<ItemPedidoEntity>();

            Itens.Add(item);

            return new CadastrarItemResponse
            {
                ChavePedido = chavePedido,
                ChaveItem = item.Chave,
                ChaveParceiro = chaveParceiro
            };
        }

        public AssociarItemPedidoResponse AssociarItemPedido(Guid chavePedido)
        {
            var item = Itens.Single(x => x.ChavePedido == chavePedido);

            item.AssociarArmazem(this);

            return new AssociarItemPedidoResponse
            {
                ChaveArmazem = Chave,
                ChavePedido = chavePedido
            };
        }

        public AssociarItemPedidoNoEstoqueResponse AssociarItemPedidoNoEstoque(ItemPedidoEntity item)
        {
            var estoque = Estoques
                .Where(x => x.ItemPedido == null
                && x.ProdutoId == item.Produto.Id
                && x.ArmazemId == item.ArmazemId)
                .FirstOrDefault();

            estoque.AssociarItem(item);

            return new AssociarItemPedidoNoEstoqueResponse
            {
                ChavePedido = item.Chave,
                ChaveEstoque = estoque.Chave
            };
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
