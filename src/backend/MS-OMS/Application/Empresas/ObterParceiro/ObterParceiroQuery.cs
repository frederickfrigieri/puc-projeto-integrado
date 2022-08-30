using Application._Configuration.Queries;
using System;
using System.Collections.Generic;

namespace Application.ObterParceiro
{
    public class ObterParceiroQuery : IQuery<IEnumerable<ObterParceiroResponse>>
    {
        public Guid ChaveParceiro { get; set; }

        public ObterParceiroQuery(Guid chaveParceiro)
        {
            ChaveParceiro = chaveParceiro;
        }
    }
}
