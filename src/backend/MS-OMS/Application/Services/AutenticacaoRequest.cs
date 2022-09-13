using System;

namespace Application.Services
{
    public class AutenticacaoRequest
    {
        public Guid ChaveParceiro { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
