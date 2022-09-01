using Application.Commands.CadastrarParceiro;
using Application.Commands.CadastrarPedido;
using Application.Commands.CadastrarProduto;
using AutoMapper;

namespace Application.Empresas
{
    public class ParceiroAutoMapperProfile : Profile
    {
        public ParceiroAutoMapperProfile()
        {
            CreateMap<CadastrarParceiroRequest, CadastrarParceiroCommand>();
            CreateMap<CadastrarPedidoRequest, CadastrarPedidoCommand>();
            CreateMap<CadastrarItemPedidoRequest, CadastrarItemPedidoCommand>();
            CreateMap<CadastrarProdutoRequest, CadastrarProdutoCommand>();
        }
    }
}
