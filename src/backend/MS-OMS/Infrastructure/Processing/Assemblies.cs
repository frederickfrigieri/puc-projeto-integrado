using Application.Commands.CadastrarParceiro;
using System.Reflection;

namespace Infrastructure.Processing
{
    public static class Assemblies
    {
        public static readonly Assembly Application = typeof(CadastrarParceiroCommand).Assembly;
    }
}