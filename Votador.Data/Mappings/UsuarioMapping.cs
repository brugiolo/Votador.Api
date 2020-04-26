using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Votador.Business.Models;

namespace Votador.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(e => e.Id).UseIdentityAlwaysColumn();

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.Senha)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.Ativo)
                .IsRequired();
        }
    }
}
