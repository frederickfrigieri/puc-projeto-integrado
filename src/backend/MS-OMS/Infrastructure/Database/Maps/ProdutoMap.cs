using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoEntity>
    {
        public void Configure(EntityTypeBuilder<ProdutoEntity> builder)
        {
            builder.ToTable("Produtos", SchemaNames.WMS);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar(1000)")
                .IsRequired();

            builder.Property(x => x.Sku)
                .HasColumnType("varchar(13)")
                .IsRequired();

            builder.HasOne(x => x.Parceiro)
                .WithMany(x => x.Produtos)
                .HasForeignKey(x => x.ParceiroId);
        }
    }
}
