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

        public async Task CadastrarParceiro(ParceiroEntity parceiro)
        {
            await _context.Parceiros.AddAsync(parceiro);
        }

        public async Task<ParceiroEntity> ObterParceiroAsync(Guid chave, string[] includes = null)
        {
            var query = _context.Parceiros.AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.SingleOrDefaultAsync(x => x.Chave == chave);
        }

        public async Task<PedidoEntity> ObterPedidoPorChaveAsync(Guid chave, string[] includes = null)
        {
            var query = _context.Pedidos.AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.SingleOrDefaultAsync(x => x.Chave == chave);
        }

        public async Task<ProdutoEntity[]> ObterProdutoPorChaveAsync(Guid[] chaves)
        {
            return await _context.Produtos
                .Where(x => chaves.Contains(x.Chave))
                .ToArrayAsync();
        }
    }
}