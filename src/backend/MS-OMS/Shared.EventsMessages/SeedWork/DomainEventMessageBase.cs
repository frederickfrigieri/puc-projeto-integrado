using System;

namespace Shared.EventsMessages.SeedWork
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