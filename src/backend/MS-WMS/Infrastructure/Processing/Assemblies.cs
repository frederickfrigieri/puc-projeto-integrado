using Application.Commands.CadastrarProduto;
using System.Reflection;

namespace Infrastructure.Processing
{
    public static class Assemblies
    {
        public static readonly Assembly Application = typeof(CadastrarProdutoCommand).Assembly;
    }
}