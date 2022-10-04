using Application._Configuration.Commands;
using Application._Configuration.Data;
using Dapper;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Processing.InternalCommands
{
    internal class ProcessInternalCommandsCommandHandler : ICommandHandler<ProcessInternalCommandsCommand, Unit>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ProcessInternalCommandsCommandHandler(
            ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Unit> Handle(ProcessInternalCommandsCommand command,
            CancellationToken cancellationToken)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();

            const string sql = "SELECT " +
                               "[Command].[Id], " +
                               "[Command].[Type], " +
                               "[Command].[Data] " +
                               "FROM [OMS].[InternalCommands] AS [Command] " +
                               "WHERE [Command].[ProcessedDate] IS NULL " +
                               "AND [Command].[Executando] = 0 " +
                               "ORDER BY OccurredOn";
            var commands = await connection.QueryAsync<InternalCommandDto>(sql);

            var internalCommandsList = commands.AsList();

            foreach (var internalCommand in internalCommandsList)
            {
                Type type = Assemblies.Application.GetType(internalCommand.Type);
                dynamic commandToProcess = JsonConvert.DeserializeObject(internalCommand.Data, type);

                await connection.ExecuteAsync("update [OMS].[InternalCommands] set Executando = 1 where id = @id",
                    new { internalCommand.Id });

                try
                {
                    await CommandsExecutor.Execute(commandToProcess);

                    await connection.ExecuteAsync("update [Jobs].[InternalCommands] set processedDate = getdate(), Executando = 0 where id = @id",
                        new { internalCommand.Id });
                }
                catch (Exception)
                {
                    await connection.ExecuteAsync("update [Jobs].[InternalCommands] set Executando = 0 where id = @id", new { internalCommand.Id });
                }
            }

            return Unit.Value;
        }

        private class InternalCommandDto
        {
            public Guid Id { get; set; }
            public string Type { get; set; }

            public string Data { get; set; }
        }
    }
}