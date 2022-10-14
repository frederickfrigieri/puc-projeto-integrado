using Application._Configuration.Data;
using Application._Configuration.Queries;
using Dapper;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ObterParceiros
{
    public class ObterParceirosQueryHandler : IQueryHandler<ObterParceirosQuery, ObterParceirosResponse[]>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly UsuarioAutenticado _autenticado;

        public ObterParceirosQueryHandler(
            ISqlConnectionFactory sqlConnectionFactory, 
            UsuarioAutenticado autenticado)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _autenticado = autenticado;
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

            if (_autenticado.Perfil == Domain.Entities.Enums.PerfilUsuario.Parceiro)
            {
                sql += string.Format(" where Chave = '{0}'", _autenticado.Chave);
            }

            sql += " order by RazaoSocial Asc";

            using var connection = _sqlConnectionFactory.GetOpenConnection();
            var query = await connection.QueryAsync<ObterParceirosResponse>(sql);

            return query
                .ToArray();
        }
    }
}
