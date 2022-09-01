using Application._Configuration.Data;
using Application._Configuration.Queries;
using Dapper;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ObterParceiro
{
    public class ObterParceiroQueryHandler : IQueryHandler<ObterParceiroQuery, ObterParceiroResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ObterParceiroQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<ObterParceiroResponse> Handle(ObterParceiroQuery request, CancellationToken cancellationToken)
        {
            var sql = @"select Chave as ChaveParceiro, RazaoSocial, Cnpj from OMS.Parceiros where Chave = @ChaveParceiro";

            using var connection = _sqlConnectionFactory.GetOpenConnection();
            var query = await connection.QuerySingleAsync<ObterParceiroResponse>(sql, new { request.ChaveParceiro });

            return query;
        }
    }
}
