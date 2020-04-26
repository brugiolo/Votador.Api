using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Votador.Business.Interfaces;
using Votador.Business.Models;
using Votador.Data.Context;

namespace Votador.Data.Repositorio
{
    public class VotoRepositorio : Repositorio<Voto>, IVotoRepositorio
    {
        public VotoRepositorio(VotadorContext contexto) : base(contexto) 
        { 
        }

        public async Task<bool> ObterVotoValido(int usuarioId, int recursoId)
        {
            return !await Contexto.Votos.AsNoTracking().AnyAsync(v => v.UsuarioId == usuarioId && v.RecursoId == recursoId);
        }
    }
}
