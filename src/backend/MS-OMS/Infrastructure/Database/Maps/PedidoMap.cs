using Domain.Entities;
using Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Database.Maps
{
    public class PedidoMap : IEntityTypeConfiguration<PedidoEntity>
    {
        public void Configure(EntityTypeBuilder<PedidoEntity> builder)
        {
            builder.ToTable("Pedidos", SchemaNames.OMS);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataCadastro)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.NomeCompleto)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Valor)
                .HasColumnType("decimal(18,12)")
                .IsRequired();

            builder.HasOne(x => x.Parceiro)
                .WithMany(x => x.Pedidos)
                .HasForeignKey(x => x.ParceiroId);

            builder.HasMany(x => x.Itens)
                .WithOne(x => x.Pedido)
                .HasForeignKey(x => x.PedidoId);

            builder.Property(x => x.StatusPedido)
                .HasConversion(src => src.ToString(),
                dst => (StatusPedidoEnum)Enum.Parse(typeof(StatusPedidoEnum), dst));
        }
    }
}
