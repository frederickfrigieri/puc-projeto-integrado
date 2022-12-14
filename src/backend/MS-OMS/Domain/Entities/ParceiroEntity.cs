using Domain._SeedWork;
using Domain.Dtos;
using Domain.Events;
using Domain.Extensions;
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
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string ChaveBling { get; set; }

        public List<PedidoEntity> Pedidos { get; private set; }
        public List<ProdutoEntity> Produtos { get; private set; }

        private ParceiroEntity(ParceiroCreateDto dto)
        {
            //TODO Validar duplicidade de CNPJ

            Cnpj = dto.Cnpj.SomenteNumeros();
            RazaoSocial = dto.RazaoSocial;
            Email = dto.Email;
            Nome = dto.Nome;
            Senha = dto.Senha;
            ChaveBling = dto.ChaveBling;

            AddDomainEvent(new ParceiroCadastradoEvent(Chave, RazaoSocial));
        }

        private ParceiroEntity() { }

        public static ParceiroEntity Criar(ParceiroCreateDto dto)
        {
            CheckRule(new ParceiroDeveTerCnpjRule(dto.Cnpj));
            CheckRule(new ParceiroDeveTerRazaoSocialRule(dto.Cnpj));

            var entity = new ParceiroEntity(dto);

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

        public ProdutoEntity CriarProduto(ProdutoDto dto)
        {
            CheckRule(new SkuDeveSerUnicoRule(dto.Sku, Produtos));

            var produto = ProdutoEntity.CriarProduto(dto);

            if (Produtos == null)
                Produtos = new List<ProdutoEntity>();

            Produtos.Add(produto);

            return produto;
        }
    }
}
