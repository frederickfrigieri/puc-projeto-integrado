using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepository
    {
        Task<Armazem> ObterArmazemAsync(Guid chave, string[] includes = null);
        Task CadastrarArmazem(Armazem armazem);
        Task<ProdutoEntity[]> ObterProdutoPorPorParceirto(Guid chaveParceiro);
    }
}
