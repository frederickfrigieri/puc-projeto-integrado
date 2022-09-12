using System;

namespace Domain._Contracts.Dto
{
    public struct NovoAcessoDto
    {
        public Guid Chave { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
