using Application._Configuration.Data;
using Application._Configuration.Queries;
using Application.ObterProdutosPorParceiro;
using Dapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ObterParceiro
{
    public class ObterProdutosQueryHandler
        : IQueryHandler<ObterProdutosQuery, IEnumerable<ObterProdutosResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly UsuarioAutenticado _autenticado;

        public ObterProdutosQueryHandler(
            ISqlConnectionFactory sqlConnectionFactory,
            UsuarioAutenticado autenticado)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _autenticado = autenticado;
        }

        public async Task<IEnumerable<ObterProdutosResponse>> Handle(
            ObterProdutosQuery request,
            CancellationToken cancellationToken)
        {
            var sql = @"select 
                        pr.Chave, 
                        pr.DataCadastro, 
                        pr.Descricao, 
                        pr.Sku, 
                        p.RazaoSocial 
                        from OMS.Produtos pr 
                        join OMS.Parceiros p on p.Id = pr.ParceiroId";

            if (_autenticado.Perfil == Domain.Entities.Enums.PerfilUsuario.Parceiro)
            {
                sql += string.Format(" where p.Chave = '{0}'", _autenticado.Chave);
            }

            sql += " order by pr.Descricao Asc";

            using var connection = _sqlConnectionFactory.GetOpenConnection();
            var query = await connection.QueryAsync<ObterProdutosResponse>(sql);

            return query.AsList();
        }
    }
}
