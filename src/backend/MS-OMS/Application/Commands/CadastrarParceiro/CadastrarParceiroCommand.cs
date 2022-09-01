using Application._Configuration.Commands;

namespace Application.Commands.CadastrarParceiro
{
    public class CadastrarParceiroCommand : CommandBase
    {
        public CadastrarParceiroCommand(string cnpj, string razaoSocial)
        {
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
        }

        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
    }
}
