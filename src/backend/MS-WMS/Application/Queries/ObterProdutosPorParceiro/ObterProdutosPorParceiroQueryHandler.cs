using Application._Configuration.Data;
using Application._Configuration.Queries;
using Application.ObterProdutosPorParceiro;
using Dapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ObterParceiro
{
    public class ObterProdutosPorParceiroQueryHandler : IQueryHandler<ObterProdutosPorParceiroQuery, IEnumerable<ObterProdutosPorParceiroResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ObterProdutosPorParceiroQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<ObterProdutosPorParceiroResponse>> Handle(
            ObterProdutosPorParceiroQuery request,
            CancellationToken cancellationToken)
        {
            var sql = @"select pr.Chave, pr.DataCadastro, pr.Descricao, pr.Sku 
                        from WMS.Produtos pr 
                        join WMS.Parceiros p on p.Id = pr.ParceiroId
                        where p.Chave = @ChaveParceiro";

            using var connection = _sqlConnectionFactory.GetOpenConnection();
            var query = await connection.QueryAsync<ObterProdutosPorParceiroResponse>(sql,
                new
                {
                    request.ChaveParceiro
                });

            return query.AsList();
        }
    }
}
