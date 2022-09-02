using Application._Configuration.Queries;
using System;
using System.Collections.Generic;

namespace Application.ObterProdutosPorParceiro
{
    public class ObterProdutosPorParceiroQuery : IQuery<IEnumerable<ObterProdutosPorParceiroResponse>>
    {
        public Guid ChaveParceiro { get; set; }

        public ObterProdutosPorParceiroQuery(Guid chaveParceiro)
        {
            ChaveParceiro = chaveParceiro;
        }
    }
}
