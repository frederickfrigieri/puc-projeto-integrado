using Domain._SeedWork;
using Domain.Dtos;
using Domain.Rules;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ParceiroEntity : Entity, IAggregateRoot
    {
        public string Cnpj { get; private set; }
        public string RazaoSocial { get; private set; }

        public List<PedidoEntity> Pedidos { get; private set; }

        private ParceiroEntity(string cnpj, string razaoSocial)
        {
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
        }

        private ParceiroEntity() { }

        public static Guid Criar(ParceiroCreateDto dto)
        {
            CheckRule(new ParceiroDeveTerCnpjRule(dto.Cnpj));
            CheckRule(new ParceiroDeveTerRazaoSocialRule(dto.Cnpj));

            var entity = new ParceiroEntity(dto.Cnpj, dto.RazaoSocial);

            return entity.Chave;
        }

        public Guid CriarPedido(PedidoDto dto)
        {
            var pedido = PedidoEntity.Criar(dto);

            if (Pedidos == null) Pedidos = new List<PedidoEntity>();

            Pedidos.Add(pedido);

            return pedido.Chave;
        }

        public Guid CriarProduto(ProdutoDto dto)
        {
            var produto = ProdutoEntity.CriarProduto(dto);

            return produto.Chave;
        }
    }
}
