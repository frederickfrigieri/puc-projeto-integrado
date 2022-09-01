using Application._Configuration.Data;
using Application._Configuration.Queries;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ObterPedidosPorParceiro
{
    public class ObterPedidosPorParceiroQueryHandler : IQueryHandler<ObterPedidosPorParceiroQuery, IEnumerable<ObterPedidosPorParceiroResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ObterPedidosPorParceiroQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<ObterPedidosPorParceiroResponse>> Handle(
            ObterPedidosPorParceiroQuery request,
            CancellationToken cancellationToken)
        {
            var sqlPedidos = @"select 
                        p.Chave, p.DataCadastro, p.NomeCompleto, p.Valor
                        from Oms.Pedidos p
                        join Oms.ItensPedidos i on i.PedidoId = p.Id
                        join OMS.Parceiros pa on pa.Id = p.ParceiroId
                        where pa.chave = @ChaveParceiro";

            var sqlItens = @"select 
                    i.Chave, i.DataCadastro, i.Quantidade, pr.Descricao as Produto
                    from Oms.Pedidos p
                    join Oms.ItensPedidos i on i.PedidoId = p.Id
                    join WMS.Produtos pr on pr.Id = i.ProdutoId
                    where p.Chave = @ChavePedido";

            var chavePedido = new { request.ChaveParceiro };

            using var connection = _sqlConnectionFactory.GetOpenConnection();
            var pedidos = await connection
                .QueryAsync<ObterPedidosPorParceiroResponse>(sqlPedidos, chavePedido);

            foreach (var pedido in pedidos)
            {
                var itens = await connection
                    .QueryAsync<ObterPedidoPorParceiroItemResponse>(sqlItens, new { ChavePedido = pedido.Chave });

                pedido.Itens = itens.ToArray();
            }

            return pedidos.ToArray();
        }
    }
}
