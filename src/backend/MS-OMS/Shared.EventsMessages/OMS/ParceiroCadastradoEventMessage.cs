using Shared.EventsMessages.SeedWork;
using System;

namespace Shared.EventsMessages.OMS
{
    public class ParceiroCriadoEventMessage : DomainEventMessageBase
    {
        public Guid ChaveParceiro { get; set; }
        public string RazaoSocial { get; set; }
    }
}
