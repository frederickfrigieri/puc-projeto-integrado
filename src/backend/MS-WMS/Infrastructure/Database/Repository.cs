using Domain;
using Domain._SeedWork;
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


        public async Task<T> AdicionarAsync<T>(T entity) where T : Entity
        {
            await _context.Set<T>().AddAsync(entity);

            return entity;
        }

        public async Task<Armazem> ObterArmazemAsync(Guid chave, string[] includes = null)
        {
            return await _context.Armazens.SingleOrDefaultAsync(c => c.Chave == chave);
        }


        public async Task<Produto[]> ObterProdutoPorChaveAsync(Guid[] chaves)
        {
            return await _context.Produtos
                .Where(x => chaves.Contains(x.Chave))
                .ToArrayAsync();
        }

        public Task<Produto[]> ObterProdutoPorPorParceiro(Guid chaveParceiro)
        {
            throw new NotImplementedException();
        }

        public async Task<Produto> ObterProdutosPorPorParceirtoESku(Guid chaveParceiro, string sku)
        {
            var produto = await _context.Produtos
                .Where(x => x.ChaveParceiro == chaveParceiro
                && x.Sku == sku)
                .SingleOrDefaultAsync();

            return produto;
        }

    }
}