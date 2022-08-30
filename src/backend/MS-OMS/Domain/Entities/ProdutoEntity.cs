using Domain._SeedWork;
using Domain.Dtos;
using Domain.Rules;
using System;

namespace Domain.Entities
{
    public class ProdutoEntity : Entity, IAggregateRoot
    {
        public string Descricao { get; private set; }
        public string Sku { get; private set; }
        public Guid ChaveParceiro { get; private set; }
        public ParceiroEntity Parceiro { get; private set; }

        private ProdutoEntity()
        {
        }

        public static ProdutoEntity CriarProduto(ProdutoDto dto)
        {
            CheckRule(new ProdutoDeveTerCamposObrigatorioPreenchidosRule(dto));

            var entity = new ProdutoEntity()
            {
                ChaveParceiro = dto.ChaveParceiro,
                Descricao = dto.Descricao,
                Sku = dto.Sku
            };

            return entity;
        }
    }
}
