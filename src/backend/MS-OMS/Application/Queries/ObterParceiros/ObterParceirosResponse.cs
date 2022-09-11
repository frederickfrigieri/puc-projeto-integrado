using System;

namespace Application.ObterParceiros
{
    public class ObterParceirosResponse
    {
        public Guid ChaveParceiro { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string ChaveBling { get; set; }
        public string Contato { get; set; }
        public string Email { get; set; }

    }
}
