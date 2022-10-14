using Domain.Entities.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Application
{
    public class UsuarioAutenticado
    {
        public UsuarioAutenticado(IHttpContextAccessor httpContextAccessor)
        {
            Chave = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Login = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Actor).Value;
            Perfil = Enum.Parse<PerfilUsuario>(httpContextAccessor.HttpContext.User.FindFirst("Perfil").Value);
        }

        public Guid Chave { get; set; }
        public string Login { get; set; }
        public PerfilUsuario Perfil { get; set; }
    }
}
