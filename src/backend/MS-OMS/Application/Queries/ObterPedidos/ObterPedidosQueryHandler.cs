using Application._Configuration.Data;
using Application._Configuration.Queries;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ObterPedidos
{
    public class ObterPedidosQueryHandler : IQueryHandler<ObterPedidosQuery, IEnumerable<ObterPedidosResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly UsuarioAutenticado _usuarioAutenticado;

        public ObterPedidosQueryHandler(
            ISqlConnectionFactory sqlConnectionFactory,
            UsuarioAutenticado usuarioAutenticado)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _usuarioAutenticado = usuarioAutenticado;
        }

        public async Task<IEnumerable<ObterPedidosResponse>> Handle(
            ObterPedidosQuery request,
            CancellationToken cancellationToken)
        {
            var sqlPedidos = @"select 
                                p.Chave, 
                                p.StatusPedido,
                                p.NomeCompleto as Cliente, 
                                --pr.Descricao as Produto, 
                                --i.Quantidade,
                                p.Valor, 
                                p.DataCadastro as DataPedido,
                                sum(i.Quantidade) as Quantidade
                                from Oms.Pedidos p
                                join Oms.ItensPedidos i on i.PedidoId = p.Id
                                join OMS.Parceiros pa on pa.Id = p.ParceiroId
                                join WMS.Produtos pr on pr.Id = i.ProdutoId";

            if (_usuarioAutenticado.Perfil == Domain.Entities.Enums.PerfilUsuario.Parceiro)
            {
                sqlPedidos += string.Format(" where pa.chave = '{0}'", _usuarioAutenticado.Chave);
            }

            sqlPedidos += " group by p.Chave, p.StatusPedido, p.NomeCompleto, p.Valor, p.DataCadastro";
            sqlPedidos += " order by p.DataCadastro Desc";

            using var connection = _sqlConnectionFactory.GetOpenConnection();
            var pedidos = await connection
                .QueryAsync<ObterPedidosResponse>(sqlPedidos);

            return pedidos.ToArray();
        }
    }
}
