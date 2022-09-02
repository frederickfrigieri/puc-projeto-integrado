using EventMessage.SeedWork;
using System;

namespace EventMessage.OMS
{
    public class ParceiroCriadoEventMessage : DomainEventMessageBase
    {
        public Guid ChaveParceiro { get; set; }
        public string RazaoSocial { get; set; }
    }
}
