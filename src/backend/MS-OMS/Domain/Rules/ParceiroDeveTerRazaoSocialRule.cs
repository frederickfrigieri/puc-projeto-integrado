using Domain._SeedWork;

namespace Domain.Rules
{
    internal class ParceiroDeveTerRazaoSocialRule : IBusinessRule
    {
        public string Message => "Razao Social náo informada";

        private readonly string _razaoSocial;

        public ParceiroDeveTerRazaoSocialRule(string razaoSocial)
        {
            _razaoSocial = razaoSocial;
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(_razaoSocial);
        }
    }
}
