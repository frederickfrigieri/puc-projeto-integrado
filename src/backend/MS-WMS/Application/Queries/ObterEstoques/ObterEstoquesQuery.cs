using Application._Configuration.Queries;
using System;

namespace Application.Queries.ObterEstoques
{
    public class ObterEstoquesQuery : IQuery<ObterEstoquesResponse[]>
    {
        public Guid ChaveParceiro { get; set; }

        public ObterEstoquesQuery(Guid chaveParceiro)
        {
            ChaveParceiro = chaveParceiro;
        }
    }
}
