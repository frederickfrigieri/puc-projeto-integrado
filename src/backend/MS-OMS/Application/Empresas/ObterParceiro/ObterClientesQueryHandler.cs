using Application._Configuration.Data;
using Application._Configuration.Queries;
using Dapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ObterParceiro
{
    public class ObterParceiroQueryHandler : IQueryHandler<ObterParceiroQuery, IEnumerable<ObterParceiroResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ObterParceiroQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<ObterParceiroResponse>> Handle(ObterParceiroQuery request, CancellationToken cancellationToken)
        {
            var sql = @"";

            using var connection = _sqlConnectionFactory.GetOpenConnection();
            var query = await connection.QueryAsync<ObterParceiroResponse>(sql, new { request.ChaveParceiro });

            return query.AsList();
        }
    }
}
