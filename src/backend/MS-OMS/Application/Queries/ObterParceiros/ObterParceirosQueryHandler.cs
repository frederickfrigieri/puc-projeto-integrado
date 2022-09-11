using Application._Configuration.Data;
using Application._Configuration.Queries;
using Dapper;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ObterParceiros
{
    public class ObterParceirosQueryHandler : IQueryHandler<ObterParceirosQuery, ObterParceirosResponse[]>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ObterParceirosQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<ObterParceirosResponse[]> Handle(ObterParceirosQuery request, CancellationToken cancellationToken)
        {
            var sql = @"select 
                        Chave as ChaveParceiro, 
                        RazaoSocial, 
                        Cnpj, 
                        ChaveBling,
                        Email, 
                        Nome As Contato
                        from OMS.Parceiros";

            using var connection = _sqlConnectionFactory.GetOpenConnection();
            var query = await connection.QueryAsync<ObterParceirosResponse>(sql);

            return query
                .AsList()
                .ToArray();
        }
    }
}
