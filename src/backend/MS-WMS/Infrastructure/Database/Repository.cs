using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class Repository : IRepository
    {
        private readonly CurrentContext _context;

        public Repository(CurrentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task CadastrarArmazem(Armazem armazem)
        {
            throw new NotImplementedException();
        }

        public Task<Armazem> ObterArmazemAsync(Guid chave, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public async Task<ProdutoEntity[]> ObterProdutoPorChaveAsync(Guid[] chaves)
        {
            return await _context.Produtos
                .Where(x => chaves.Contains(x.Chave))
                .ToArrayAsync();
        }

        public Task<ProdutoEntity[]> ObterProdutoPorPorParceirto(Guid chaveParceiro)
        {
            throw new NotImplementedException();
        }
    }
}