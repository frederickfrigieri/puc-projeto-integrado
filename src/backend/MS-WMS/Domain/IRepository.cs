using Domain._SeedWork;
using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepository
    {
        Task<Armazem> ObterArmazemAsync(Guid chave, string[] includes = null);
        Task<Produto[]> ObterProdutoPorPorParceiro(Guid chaveParceiro);
        Task<Produto> ObterProdutosPorPorParceirtoESku(Guid chaveParceiro, string sku);
        Task<T> AdicionarAsync<T>(T entity) where T : Entity;
        Task<Produto[]> ObterProdutoPorChaveAsync(Guid[] chaves);
    }
}
