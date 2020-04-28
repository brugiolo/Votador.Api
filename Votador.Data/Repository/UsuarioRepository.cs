using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Votador.Business.Interfaces;
using Votador.Business.Models;
using Votador.Data.Context;

namespace Votador.Data.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(VotadorContext context) : base(context) 
        { 
        }

        public async Task<Usuario> ObterUsuarioLogin(string email)
        {
            return await Contexto.Usuarios.AsNoTracking().FirstOrDefaultAsync(v => v.Email == email);
        }
    }
}
