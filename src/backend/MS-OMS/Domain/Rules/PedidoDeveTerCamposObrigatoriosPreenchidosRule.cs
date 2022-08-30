using Domain._SeedWork;
using Domain.Dtos;

namespace Domain.Rules
{
    internal class PedidoDeveTerCamposObrigatoriosPreenchidosRule : IBusinessRule
    {
        public string Message => throw new System.NotImplementedException();

        private readonly PedidoDto _pedidoDto;

        public PedidoDeveTerCamposObrigatoriosPreenchidosRule(PedidoDto pedidoDto)
        {
            _pedidoDto = pedidoDto;
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(_pedidoDto.Nome)
                && _pedidoDto.ChaveParceiro != null;

        }
    }
}