using System;

namespace Domain._SeedWork
{
    public class DomainEventBase : IDomainEvent
    {
        public DomainEventBase()
        {
            this.OccurredOn = DateTime.Now;
        }

        public DateTime OccurredOn { get; }
    }
}