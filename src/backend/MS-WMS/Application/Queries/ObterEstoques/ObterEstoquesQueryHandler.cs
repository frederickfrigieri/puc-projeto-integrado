using Application._Configuration.Data;
using Application._Configuration.Queries;
using Dapper;
using Serilog.RequestResponse.Extensions.Exceptions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.ObterEstoques
{
    public class ObterEstoquesQueryHandler : IQueryHandler<ObterEstoquesQuery, ObterEstoquesResponse[]>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly UsuarioAutenticado _autenticado;

        public ObterEstoquesQueryHandler(ISqlConnectionFactory sqlConnectionFactory, UsuarioAutenticado autenticado)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _autenticado = autenticado;
        }

        public async Task<ObterEstoquesResponse[]> Handle(ObterEstoquesQuery request, CancellationToken cancellationToken)
        {
            var sql = @"select pr.Descricao, 
                        pr.Sku, 
                        pa.RazaoSocial as Parceiro, 
                        a.Descricao as Armazem,
                        count(e.Id) as Quantidade
                        from WMS.Estoques e
                        join wms.Produtos pr on pr.Id = e.ProdutoId
                        join OMS.Parceiros pa on pa.Chave = e.ChaveParceiro
                        join wms.Armazens a on a.Id = e.ArmazemId
                        where e.PedidoItemId is null";

            if (_autenticado.Perfil == Domain.Enums.PerfilUsuario.Parceiro)
            {
                if (_autenticado.Chave != request.ChaveParceiro)
                    throw new DomainException("Chave do Parceiro diferente da Sessão");

                sql += string.Format(" and e.ChaveParceiro = '{0}'", _autenticado.Chave);
            }

            sql += " group by pr.Descricao, pr.Chave, pa.RazaoSocial, pr.Sku, a.Descricao";
            
            using var connection = _sqlConnectionFactory.GetOpenConnection();
            var query = await connection.QueryAsync<ObterEstoquesResponse>(sql);

            return query.ToArray();
        }
    }
}
