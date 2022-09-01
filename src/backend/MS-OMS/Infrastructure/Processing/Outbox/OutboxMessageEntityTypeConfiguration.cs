using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Processing.Outbox
{
    internal sealed class OutboxMessageEntityTypeConfiguration : IEntityTypeConfiguration<OutboxMessage>
    {
        public void Configure(EntityTypeBuilder<OutboxMessage> builder)
        {
            builder.ToTable("OutboxMessages", SchemaNames.Jobs);

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedNever();


            builder.Property(b => b.Type).IsUnicode(false).HasMaxLength(8000);
            builder.Property(b => b.Data).IsUnicode(false).HasMaxLength(8000);
        }
    }
}