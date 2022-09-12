using System;

namespace Application.Services.Dto
{
    public struct TokenPropertiesDto
    {
        public string Login { get; set; }
        public Guid Chave { get; set; }
        public DateTime Data { get; set; }
    }
}
