namespace Application.Commands.CadastrarParceiro
{
    public class CadastrarParceiroRequest
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string ChaveBling { get; set; }
    }
}
