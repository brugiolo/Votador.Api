using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Votador.Business.Models;

namespace Votador.Data.Context
{
    public partial class VotadorContext : DbContext
    {
        public VotadorContext() { }

        public VotadorContext(DbContextOptions<VotadorContext> options) : base(options) { }

        public virtual DbSet<Recurso> Recursos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Voto> Votos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
