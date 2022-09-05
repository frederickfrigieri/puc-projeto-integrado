using System;

namespace Domain.Dtos
{
    public class EstoqueCadastroDto
    {
        public int Armazem { get; set; }
        public int Produto { get; set; }
        public Guid ChaveParceiro { get; set; }
    }
}
