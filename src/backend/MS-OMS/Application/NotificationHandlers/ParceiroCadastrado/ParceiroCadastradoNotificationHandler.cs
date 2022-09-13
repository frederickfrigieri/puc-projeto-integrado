using Application.Services;
using Application.Services.Contracts;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NotificationHandlers.ParceiroCadastrado
{
    public class ParceiroCadastradoNotificationHandler : INotificationHandler<ParceiroCadastradoNotification>
    {
        private readonly IAutenticacao _autenticacao;
        private readonly IRepository _repository;

        public ParceiroCadastradoNotificationHandler(IAutenticacao autenticacao, IRepository repository)
        {
            _autenticacao = autenticacao;
            _repository = repository;
        }

        public async Task Handle(ParceiroCadastradoNotification notification, CancellationToken cancellationToken)
        {
            var parceiro = await _repository.ObterParceiroAsync(notification.ChaveParceiro);

            var dto = new AutenticacaoRequest
            {
                ChaveParceiro = parceiro.Chave,
                Login = parceiro.Email,
                Password = parceiro.Senha
            };

            await _autenticacao.Cadastrar(dto);
        }
    }
}
