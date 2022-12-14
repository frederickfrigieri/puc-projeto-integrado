using System;

namespace Infrastructure.Processing.InternalCommands
{
    public class InternalCommand
    {
        public Guid Id { get; set; }

        public DateTime OccurredOn { get; set; }

        public string Type { get; set; }

        public string Data { get; set; }

        public DateTime? ProcessedDate { get; set; }

        public bool Executando { get; set; }
    }
}