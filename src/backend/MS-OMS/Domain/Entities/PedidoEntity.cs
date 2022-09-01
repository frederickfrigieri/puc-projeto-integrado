using Domain._SeedWork;
using Domain.Dtos;
using Domain.Events;
using Domain.Rules;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class PedidoEntity : Entity, IAggregateRoot
    {
        public string NomeCompleto { get; private set; }
        public decimal Valor { get; private set; }

        public int ParceiroId { get; set; }
        public ParceiroEntity Parceiro { get; set; }

        public List<ItemPedidoEntity> Itens { get; private set; }



        public PedidoEntity() { }

        private PedidoEntity(PedidoDto dto)
        {
            CheckRule(new PedidoDeveTerCamposObrigatoriosPreenchidosRule(dto));
            CheckRule(new PedidoDeveTerItemRule(dto.Itens));

            NomeCompleto = dto.Nome;
            Valor = dto.Valor;
            Itens = new List<ItemPedidoEntity>();

            dto.Itens.ForEach(itemDto =>
            {
                var item = ItemPedidoEntity.Criar(itemDto);
                Itens.Add(item);
            });

            AddDomainEvent(new PedidoCriadoEvent(Chave));
        }

        public static PedidoEntity Criar(PedidoDto dto)
        {
            var pedido = new PedidoEntity(dto);

            return pedido;
        }
    }

}
