using Serilog.RequestResponse.Extensions.Exceptions;
using System;
using System.Collections.Generic;

namespace Domain._SeedWork
{
    /// <summary>
    /// Base class for entities.
    /// </summary>
    public abstract class Entity
    {
        private List<IDomainEvent> _domainEvents;

        public Guid Chave { get; set; }
        public DateTime DataCadastro { get; set; }


        /// <summary>
        /// Domain events occurred.
        /// </summary>
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        internal Entity()
        {
            Chave = Guid.NewGuid();
            DataCadastro = DateTime.Now;
        }

        /// <summary>
        /// Add domain event.
        /// </summary>
        /// <param name="domainEvent"></param>
        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            this._domainEvents.Add(domainEvent);
        }

        /// <summary>
        /// Clear domain events.
        /// </summary>
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        protected static void CheckRule(IBusinessRule rule)
        {
            if (!rule.IsValid())
            {
                throw new DomainException(rule.Message);
            }
        }
    }
}