using Domain.Entities;
using Infrastructure.Processing.InternalCommands;
using Infrastructure.Processing.Outbox;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Database
{
    public class CurrentContext : DbContext
    {
        public DbSet<OutboxMessage> OutboxMessages { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoItem> PedidosItens { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Posicao> Posicoes { get; set; }
        public DbSet<InternalCommand> InternalCommands { get; set; }
        public DbSet<Armazem> Armazens { get; set; }


        public CurrentContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CurrentContext).Assembly);

            foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
            {
                if (property.GetMaxLength() == null)
                {
                    property.SetMaxLength(256);
                }
            }

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
