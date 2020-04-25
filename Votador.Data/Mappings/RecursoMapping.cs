using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
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

            //builder.HasOne(d => d.Usuario)
            //    .WithMany(p => p.Recursos)
            //    .HasForeignKey(d => d.UsuarioId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("Recursos_UsuarioId_fkey");
        }
    }
}
