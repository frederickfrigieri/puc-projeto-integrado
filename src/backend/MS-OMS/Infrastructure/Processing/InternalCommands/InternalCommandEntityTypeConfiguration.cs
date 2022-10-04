using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Processing.InternalCommands
{
    internal sealed class InternalCommandEntityTypeConfiguration : IEntityTypeConfiguration<InternalCommand>
    {
        public void Configure(EntityTypeBuilder<InternalCommand> builder)
        {
            builder.ToTable("InternalCommands", SchemaNames.OMS);

            builder.Property(x => x.Type).HasColumnType("Varchar(250)");
            builder.Property(x => x.Data).HasColumnType("Varchar(Max)");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedNever();

            builder.Property(b => b.Type).HasMaxLength(8000);
            builder.Property(b => b.Data).HasMaxLength(8000);
        }
    }
}