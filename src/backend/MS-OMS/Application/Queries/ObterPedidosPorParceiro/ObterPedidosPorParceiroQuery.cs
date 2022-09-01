using Application._Configuration.Queries;
using System;
using System.Collections.Generic;

namespace Application.ObterPedidosPorParceiro
{
    public class ObterPedidosPorParceiroQuery : IQuery<IEnumerable<ObterPedidosPorParceiroResponse>>
    {
        public Guid ChaveParceiro { get; set; }

        public ObterPedidosPorParceiroQuery(Guid chaveParceiro)
        {
            ChaveParceiro = chaveParceiro;
        }
    }
}
