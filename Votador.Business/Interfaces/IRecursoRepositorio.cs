using System.Collections.Generic;
using System.Threading.Tasks;
using Votador.Business.Models;

namespace Votador.Business.Interfaces
{
    public interface IRecursoRepositorio : IRepositorio<Recurso>
    {
        Task<IEnumerable<RecursoVoto>> ObterRecursosMaisVotados();
    }
}
