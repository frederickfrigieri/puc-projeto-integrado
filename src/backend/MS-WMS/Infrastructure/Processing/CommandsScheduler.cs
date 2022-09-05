using Application._Configuration.Commands;
using Application._Configuration.Data;
using Application._Configuration.Processing;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Processing
{
    public class CommandsScheduler : ICommandsScheduler
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public CommandsScheduler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task EnqueueAsync<T>(ICommand<T> command)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();

            const string sqlInsert = "INSERT INTO [Jobs].[InternalCommands] ([Id], [OccurredOn], [Type], [Data]) VALUES " +
                                     "(@Id, @OccurredOn, @Type, @Data)";

            await connection.ExecuteAsync(sqlInsert, new
            {
                command.Id,
                OccurredOn = DateTime.UtcNow,
                Type = command.GetType().FullName,
                Data = JsonConvert.SerializeObject(command)
            });
        }

        public async Task EnqueueAsync(ICommand command)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();

            const string sqlInsert = "INSERT INTO [Jobs].[InternalCommands] ([Id], " +
                "                     [OccurredOn], [Type], [Data], Executando) VALUES " +
                                     "(@Id, @OccurredOn, @Type, @Data, 0)";

            await connection.ExecuteAsync(sqlInsert, new
            {
                command.Id,
                OccurredOn = DateTime.UtcNow,
                Type = command.GetType().FullName,
                Data = JsonConvert.SerializeObject(command)
            });
        }
    }
}