using Application.Commands.CadastrarEstoque;
using Application.Commands.CadastrarProduto;
using AutoMapper;

namespace Application.Empresas
{
    public class ParceiroAutoMapperProfile : Profile
    {
        public ParceiroAutoMapperProfile()
        {
            CreateMap<CadastrarProdutoRequest, CadastrarProdutoCommand>();
            CreateMap<CadastrarEstoqueRequest, CadastrarEstoqueCommand>();

        }
    }
}
