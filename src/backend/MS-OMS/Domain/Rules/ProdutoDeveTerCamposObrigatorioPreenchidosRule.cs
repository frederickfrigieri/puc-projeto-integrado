using Domain._SeedWork;
using Domain.Dtos;

namespace Domain.Rules
{
    public class ProdutoDeveTerCamposObrigatorioPreenchidosRule : IBusinessRule
    {
        public string Message => throw new System.NotImplementedException();

        private readonly ProdutoDto _dto;

        public ProdutoDeveTerCamposObrigatorioPreenchidosRule(ProdutoDto dto)
        {
            _dto = dto;
        }

        public bool IsValid()
        {
            return _dto.ChaveParceiro != null
                && !string.IsNullOrWhiteSpace(_dto.Descricao)
                && !string.IsNullOrWhiteSpace(_dto.Sku);
        }
    }
}