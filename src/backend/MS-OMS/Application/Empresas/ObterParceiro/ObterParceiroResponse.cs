using System;

namespace Application.ObterParceiro
{
    public class ObterParceiroResponse
    {
        public Guid ChaveParceiro { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
    }
}
