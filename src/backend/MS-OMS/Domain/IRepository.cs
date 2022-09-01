﻿using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepository
    {
        Task<ParceiroEntity> ObterParceiroAsync(Guid chave, string[] includes = null);
        Task CadastrarParceiro(ParceiroEntity parceiro);

        Task<ProdutoEntity[]> ObterProdutoPorChaveAsync(Guid[] chaves);
    }
}
