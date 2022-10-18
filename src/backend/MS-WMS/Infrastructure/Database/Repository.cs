using Domain;
using Domain._SeedWork;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<Armazem[]> ObterArmazemMenorQuantidadePedido()
        {
            return await _context.Armazens
                .Include(x => x.Estoques)
                .OrderBy(x => x.Itens.Count())
                .ToArrayAsync();
        }

        public async Task<Estoque> ObterEstoqueDisponivel(
            int produtoId,
            int armazemId,
            Guid chaveParceiro)
        {
            return await _context.Estoques
                .Where(x => x.ProdutoId == produtoId
                && x.PedidoItem == null
                && x.Posicao != null
                && x.ArmazemId == armazemId
                && x.ChaveParceiro == chaveParceiro)
                .FirstOrDefaultAsync();
        }

        public async Task<PedidoItem[]> ObterItensPorPedido(Guid chavePedido)
        {
            return await _context.PedidosItens
                .Where(x => x.ChavePedido == chavePedido)
                .ToArrayAsync();
        }

        public async Task<Produto[]> ObterProdutoPorChaveAsync(Guid[] chaves)
        {
            return await _context.Produtos
                .Where(x => chaves.Contains(x.Chave))
                .ToArrayAsync();
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