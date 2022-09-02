using EventMessage.SeedWork;
using System;

namespace EventMessage.WMS
{
    public class ParceiroCriadoEventMessage : DomainEventMessageBase
    {
        public Guid ChaveParceiro { get; set; }
    }
}
