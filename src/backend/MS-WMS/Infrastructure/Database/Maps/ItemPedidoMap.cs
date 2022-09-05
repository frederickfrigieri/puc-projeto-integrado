using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Maps
{
    public class ItemPedidoMap : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.ToTable("ItensPedidos", SchemaNames.OMS);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantidade)
                .HasColumnType("tinyint")
                .IsRequired();

            builder.HasOne(x => x.Produto)
                .WithMany(x => x.ItensPedidos)
                .HasForeignKey(x => x.ProdutoId);

            builder.HasOne(x => x.Armazem)
                .WithMany(x => x.Itens)
                .HasForeignKey(x => x.ArmazemId)
                .IsRequired(false);
        }
    }
}
