using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Votador.Business.Models;

namespace Votador.Data.Mappings
{
    public class RecursoMapping : IEntityTypeConfiguration<Recurso>
    {
        public void Configure(EntityTypeBuilder<Recurso> builder)
        {
            builder.Property(e => e.Id).UseIdentityAlwaysColumn();

            builder.Property(e => e.Titulo)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.DataHoraCadastro).HasColumnType("timestamp with time zone");

            builder.Property(e => e.NomeDoAutor)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.EmailDoAutor)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
