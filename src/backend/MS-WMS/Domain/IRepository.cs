using Domain._SeedWork;
using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepository
    {
        Task<Armazem> ObterArmazemAsync(Guid chave, string[] includes = null);
        //Task CadastrarArmazem(Armazem armazem);
        Task<Produto[]> ObterProdutoPorPorParceirto(Guid chaveParceiro);
        //Task<Parceiro> ObterParceiroPorChaveAsync(Guid chave, string[] includes = null);
        //Task CadastrarParceiro(Parceiro parceiro);
        Task<Produto> ObterProdutosPorPorParceirtoESku(Guid chaveParceiro, string sku);
        Task<T> Adicionar<T>(T entity) where T : Entity;

    }
}
