using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Votador.Business.Interfaces;
using Votador.Business.Models;
using Votador.Data.Context;

namespace Votador.Data.Repositorio
{
    public class RecursoRepositorio : Repositorio<Recurso>, IRecursoRepositorio
    {
        public RecursoRepositorio(VotadorContext context) : base(context) { }

        public async Task<IEnumerable<RecursoVoto>> ObterRecursosMaisVotados()
        {
            var recursos = (
                from r in Contexto.Recursos
                select new RecursoVoto 
                {
                    Recurso = r,
                    NumeroDeVotos = r.Votos.Count()
                }).OrderByDescending(r => r.NumeroDeVotos).ToListAsync();

            return await recursos;
        }
    }
}
