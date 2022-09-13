using Domain._SeedWork;
using Domain.Dtos;
using Domain.Rules;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ProdutoEntity : Entity, IAggregateRoot
    {
        public string Descricao { get; private set; }
        public string Sku { get; private set; }

        public int ParceiroId { get; private set; }
        public ParceiroEntity Parceiro { get; private set; }

        public List<ItemPedidoEntity> ItensPedidos { get; private set; }


        private ProdutoEntity()
        {
        }

        public static ProdutoEntity CriarProduto(ProdutoDto dto)
        {
            CheckRule(new ProdutoDeveTerCamposObrigatorioPreenchidosRule(dto));

            var entity = new ProdutoEntity()
            {
                ParceiroId = dto.ParceiroId,
                Descricao = dto.Descricao,
                Sku = dto.Sku,
                Chave = dto.ChaveProduto
            };

            return entity;
        }
    }
}
