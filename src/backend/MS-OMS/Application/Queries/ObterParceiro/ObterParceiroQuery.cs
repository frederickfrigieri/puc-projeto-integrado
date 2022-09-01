using Application._Configuration.Queries;
using System;

namespace Application.ObterParceiro
{
    public class ObterParceiroQuery : IQuery<ObterParceiroResponse>
    {
        public Guid ChaveParceiro { get; set; }

        public ObterParceiroQuery(Guid chaveParceiro)
        {
            ChaveParceiro = chaveParceiro;
        }
    }
}
