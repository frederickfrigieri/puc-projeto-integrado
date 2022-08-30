using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<ParceiroEntity> ObterParceiroAsync(Guid chave)
        {
            return await _context.Parceiros.SingleOrDefaultAsync(x => x.Chave == chave);
        }
    }
}