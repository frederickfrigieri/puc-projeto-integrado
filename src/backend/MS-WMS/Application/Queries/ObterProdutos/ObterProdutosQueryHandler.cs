using Application._Configuration.Data;
using Application._Configuration.Queries;
using Application.ObterProdutos;
using Dapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ObterParceiro
{
    public class ObterProdutosQueryHandler : IQueryHandler<ObterProdutosQuery, IEnumerable<ObterProdutosResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly UsuarioAutenticado _usuarioAutenticado;

        public ObterProdutosQueryHandler(
            ISqlConnectionFactory sqlConnectionFactory,
            UsuarioAutenticado usuarioAutenticado)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _usuarioAutenticado = usuarioAutenticado;
        }

        public async Task<IEnumerable<ObterProdutosResponse>> Handle(
            ObterProdutosQuery request,
            CancellationToken cancellationToken)
        {
            var sql = @"select pr.Chave, pr.DataCadastro, pr.Descricao, pr.Sku 
                        from WMS.Produtos pr";

            if (_usuarioAutenticado.Perfil == Domain.Enums.PerfilUsuario.Parceiro)
            {
                sql += string.Format(" where pr.ChaveParceiro = '{0}'", _usuarioAutenticado.Chave);
            }

            sql += " order by pr.Descricao Asc";

            using var connection = _sqlConnectionFactory.GetOpenConnection();
            var query = await connection.QueryAsync<ObterProdutosResponse>(sql);

            return query.AsList();
        }
    }
}
