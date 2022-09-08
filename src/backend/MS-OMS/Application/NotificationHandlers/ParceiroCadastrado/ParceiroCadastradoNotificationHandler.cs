﻿using Application._Configuration.MessageBus;
using MediatR;
using Serilog.RequestResponse.Extensions.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NotificationHandlers.ParceiroCadastrado
{
    public class ParceiroCadastradoNotificationHandler : INotificationHandler<ParceiroCadastradoNotification>
    {
        private readonly IMessageBus _messageBus;

        public ParceiroCadastradoNotificationHandler(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public Task Handle(ParceiroCadastradoNotification notification, CancellationToken cancellationToken)
        {
            //var message = new ParceiroCriadoEventMessage
            //{
            //    RazaoSocial = notification.RazaoSocial,
            //    ChaveParceiro = notification.ChaveParceiro
            //};

            //_messageBus.Publish(message);

            //return Task.CompletedTask;

            throw new DomainException($"NotificationHandler náo implementado. {typeof(ParceiroCadastradoNotificationHandler)}");
        }
    }
}