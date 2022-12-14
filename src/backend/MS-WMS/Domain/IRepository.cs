using Domain._SeedWork;
using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepository
    {
        Task<T> AdicionarAsync<T>(T entity) where T : Entity;
        
        Task<Armazem> ObterArmazemAsync(Guid chave, string[] includes = null);
        Task<Armazem> ObterArmazemMenorQuantidadePedido(); 
        
        Task<Produto[]> ObterProdutoPorPorParceiro(Guid chaveParceiro);
        Task<Produto> ObterProdutosPorPorParceirtoESku(Guid chaveParceiro, string sku);
        Task<Produto[]> ObterProdutoPorChaveAsync(Guid[] chaves);
        
        Task<PedidoItem[]> ObterPedidosSemArmazem();
        Task<PedidoItem[]> ObterPedidosSemEstoque();
        
        Task<Estoque> ObterEstoqueDisponivel(
            int produtoId,
            int armazemId,
            Guid chaveParceiro);
    }
}
