using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepository
    {
        Task<ParceiroEntity> ObterParceiroAsync(Guid chave);
        Task CadastrarParceiro(ParceiroEntity parceiro);
    }
}
