using Application._Configuration.Data;
using Application._Configuration.Queries;
using Dapper;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.ObterArmazens
{
    public class ObterArmazemQueryHandler : IQueryHandler<ObterArmazemQuery, ObterArmazemResponse[]>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ObterArmazemQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<ObterArmazemResponse[]> Handle(ObterArmazemQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.GetOpenConnection();
            var sql = "select Chave as ChaveArmazem, Descricao from WMS.Armazens";
            var query = await connection.QueryAsync<ObterArmazemResponse>(sql);

            return query.ToArray();
        }
    }
}
