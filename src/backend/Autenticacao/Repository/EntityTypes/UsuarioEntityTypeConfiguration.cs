using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.EntityTypes
{
    public class UsuarioEntityTypeConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios", "Identidade");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataCadastro)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.Perfil)
                .HasColumnType("varchar(10)")
                .HasConversion<string>();
        }
    }
}
