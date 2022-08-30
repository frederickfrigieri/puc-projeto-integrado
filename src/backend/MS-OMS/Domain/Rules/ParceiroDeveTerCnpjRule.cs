using Domain._SeedWork;

namespace Domain.Rules
{
    public class ParceiroDeveTerCnpjRule : IBusinessRule
    {

        private readonly string _cnjp;

        public ParceiroDeveTerCnpjRule(string cnjp)
        {
            _cnjp = cnjp;
        }

        public string Message => "CNPJ do parceiro náo informado";

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(_cnjp);
        }
    }
}
