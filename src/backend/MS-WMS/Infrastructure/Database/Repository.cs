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


        public async Task<T> Adicionar<T>(T entity) where T : Entity
        {
            await _context.Set<T>().AddAsync(entity);

            return entity;
        }

        //public Task CadastrarArmazem(Armazem armazem)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task CadastrarParceiro(Parceiro parceiro)
        //{
        //    await _context.Parceiros.AddAsync(parceiro);
        //}

        public Task<Armazem> ObterArmazemAsync(Guid chave, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        //public async Task<Parceiro> ObterParceiroPorChaveAsync(Guid chave, string[] includes = null)
        //{
        //    return await _context.Parceiros.SingleOrDefaultAsync(x => x.Chave == chave);
        //}

        public async Task<Produto[]> ObterProdutoPorChaveAsync(Guid[] chaves)
        {
            return await _context.Produtos
                .Where(x => chaves.Contains(x.Chave))
                .ToArrayAsync();
        }

        public Task<Produto[]> ObterProdutoPorPorParceirto(Guid chaveParceiro)
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