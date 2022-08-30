using Application._Configuration.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CadastrarParceiro
{
    public class CadastrarParceiroCommandHandler : ICommandHandler<CadastrarParceiroCommand>
    {
        public Task<Unit> Handle(CadastrarParceiroCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
