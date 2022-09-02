using Application._Configuration.DomainEvents;
using Domain.Events;
using System;
using System.Text.Json.Serialization;

namespace Application.NotificationHandlers.ParceiroCadastrado
{
    public class ParceiroCadastradoNotification : DomainNotificationBase<ParceiroCadastradoEvent>
    {
        public ParceiroCadastradoNotification(ParceiroCadastradoEvent domainEvent) : base(domainEvent)
        {
            ChaveParceiro = domainEvent.ChaveParceiro;
            RazaoSocial = domainEvent.RazaoSocial;
        }

        public Guid ChaveParceiro { get; set; }
        public string RazaoSocial { get; set; }

        [JsonConstructor]
        public ParceiroCadastradoNotification() : base(null)
        {
        }
    }
}
