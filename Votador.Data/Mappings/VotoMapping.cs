using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Votador.Business.Models;

namespace Votador.Data.Mappings
{
    public class VotoMapping : IEntityTypeConfiguration<Voto>
    {
        public void Configure(EntityTypeBuilder<Voto> builder)
        {
            builder.Property(e => e.Id).UseIdentityAlwaysColumn();

            builder.Property(e => e.Comentario)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.DataHoraVoto).HasColumnType("timestamp with time zone");

            builder.HasOne(d => d.Recurso)
                .WithMany(p => p.Votos)
                .HasForeignKey(d => d.RecursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Votos_RecursoId_fkey");

            builder.HasOne(d => d.Usuario)
                .WithMany(p => p.Votos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Votos_UsuarioId_fkey");
        }
    }
}
