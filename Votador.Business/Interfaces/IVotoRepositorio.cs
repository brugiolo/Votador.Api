using System.Threading.Tasks;
using Votador.Business.Models;

namespace Votador.Business.Interfaces
{
    public interface IVotoRepositorio : IRepositorio<Voto>
    {
        Task<bool> ObterVotoValido(int usuarioId, int recursoId);
    }
}
