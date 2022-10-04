using Application._Configuration.Commands;
using Application._Configuration.Data;
using Application._Configuration.DomainEvents;
using Dapper;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Processing.Outbox
{
    internal class ProcessOutboxCommandHandler : ICommandHandler<ProcessOutboxCommand, Unit>
    {
        private readonly IMediator _mediator;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ProcessOutboxCommandHandler(ISqlConnectionFactory sqlConnectionFactory, IMediator mediator)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(ProcessOutboxCommand command, CancellationToken cancellationToken)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();
            const string sql = "SELECT " +
                               "[OutboxMessage].[Id], " +
                               "[OutboxMessage].[Type], " +
                               "[OutboxMessage].[Data] " +
                               "FROM [OMS].[OutboxMessages] AS [OutboxMessage] " +
                               "WHERE [OutboxMessage].[ProcessedDate] IS NULL " +
                               "ORDER BY [OutboxMessage].[OccurredOn]";

            var messages = await connection.QueryAsync<OutboxMessageDto>(sql);
            var messagesList = messages.AsList();

            const string sqlUpdateProcessedDate = "UPDATE [OMS].[OutboxMessages] " +
                                                  "SET [ProcessedDate] = @Date " +
                                                  "WHERE [Id] = @Id";
            if (messagesList.Count > 0)
            {
                foreach (var message in messagesList)
                {
                    Type type = Assemblies.Application.GetType(message.Type);

                    var request = JsonConvert.DeserializeObject(message.Data, type) as IDomainEventNotification;

                    await _mediator.Publish(request);

                    connection = this._sqlConnectionFactory.GetOpenConnection();

                    await connection.ExecuteAsync(sqlUpdateProcessedDate, new
                    {
                        Date = DateTime.UtcNow,
                        message.Id
                    });

                }
            }

            return Unit.Value;
        }

    }
}