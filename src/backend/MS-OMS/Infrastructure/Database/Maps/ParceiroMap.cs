using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Maps
{
    public class ParceiroMap : IEntityTypeConfiguration<ParceiroEntity>
    {
        public void Configure(EntityTypeBuilder<ParceiroEntity> builder)
        {
            builder.ToTable("Parceiros", SchemaNames.OMS);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Cnpj)
                .HasColumnType("varchar(14)")
                .IsRequired();

            builder.Property(x => x.RazaoSocial)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.DataCadastro)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}
