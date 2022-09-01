using Domain._SeedWork;
using Domain.Dtos;
using Domain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class ParceiroEntity : Entity, IAggregateRoot
    {
        public string Cnpj { get; private set; }
        public string RazaoSocial { get; private set; }

        public List<PedidoEntity> Pedidos { get; private set; }
        public List<ProdutoEntity> Produtos { get; private set; }

        private ParceiroEntity(string cnpj, string razaoSocial)
        {
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
        }

        private ParceiroEntity() { }

        public static ParceiroEntity Criar(ParceiroCreateDto dto)
        {
            CheckRule(new ParceiroDeveTerCnpjRule(dto.Cnpj));
            CheckRule(new ParceiroDeveTerRazaoSocialRule(dto.Cnpj));

            var entity = new ParceiroEntity(dto.Cnpj, dto.RazaoSocial);

            return entity;
        }

        public Guid CriarPedido(PedidoDto dto)
        {
            CheckRule(new ParceiroDeveTerUmOuMaisProdutoRule(Produtos));
            CheckRule(new ItensDeveTerProdutoRule(dto.Itens, Produtos));

            dto.Itens.ForEach(item => item.ProdutoId = Produtos.Single(x => x.Chave == item.ChaveProduto).Id);

            var pedido = PedidoEntity.Criar(dto);

            if (Pedidos == null) Pedidos = new List<PedidoEntity>();

            Pedidos.Add(pedido);

            return pedido.Chave;
        }

        public Guid CriarProduto(ProdutoDto dto)
        {
            CheckRule(new SkuDeveSerUnicoRule(dto.Sku, Produtos));

            var produto = ProdutoEntity.CriarProduto(dto);

            if (Produtos == null)
                Produtos = new List<ProdutoEntity>();

            Produtos.Add(produto);

            return produto.Chave;
        }
    }
}
