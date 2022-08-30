using System;

namespace EventMessage.SeedWork
{
    public class DomainEventMessageBase
    {
        public Guid Id { get; }

        public DomainEventMessageBase()
        {
            this.Id = Guid.NewGuid();
        }
    }
}