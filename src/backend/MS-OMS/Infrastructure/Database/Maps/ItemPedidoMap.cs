using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Maps
{
    public class ItemPedidoMap : IEntityTypeConfiguration<ItemPedidoEntity>
    {
        public void Configure(EntityTypeBuilder<ItemPedidoEntity> builder)
        {
            builder.ToTable("ItensPedidos", SchemaNames.OMS);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantidade)
                .HasColumnType("tinyint")
                .IsRequired();

            builder.HasOne(x => x.Produto)
                .WithMany(x => x.ItensPedidos)
                .HasForeignKey(x => x.ProdutoId);
        }
    }
}
