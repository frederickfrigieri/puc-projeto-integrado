using Domain._SeedWork;
using System;

namespace Domain.Events
{
    public class ParceiroCadastradoEvent : DomainEventBase
    {
        public Guid ChaveParceiro { get; set; }
        public string RazaoSocial { get; set; }

        public ParceiroCadastradoEvent(Guid chaveParceiro, string razaoSocial)
        {
            ChaveParceiro = chaveParceiro;
            RazaoSocial = razaoSocial;
        }
    }
}
