using Application._Configuration.DomainEvents;
using Domain.Events;
using System;
using System.Text.Json.Serialization;

namespace Application.NotificationHandlers.ProdutoCadastrado
{
    public class ProdutoCadastradoNotification : DomainNotificationBase<ProdutoCadastradoEvent>
    {
        public ProdutoCadastradoNotification(ProdutoCadastradoEvent domainEvent) : base(domainEvent)
        {
            ChaveProduto = domainEvent.ChaveProduto;
            Descricao = domainEvent.Descricao;
            ChaveParceiro = domainEvent.ChaveParceiro;
            Sku = domainEvent.Sku;
        }

        public Guid ChaveProduto { get; set; }
        public Guid ChaveParceiro { get; set; }
        public string Descricao { get; set; }
        public string Sku { get; set; }

        [JsonConstructor]
        public ProdutoCadastradoNotification() : base(null)
        {
        }
    }
}
