using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Votador.Business.Models;

namespace Votador.Business.Interfaces
{
    public interface IUsuarioService : IDisposable
    {
        Task Incluir(Usuario entidade);
        Task<Usuario> Obter(int id);
        Task Atualizar(Usuario entidade);
        Task Deletar(int id);
        Task<List<Usuario>> Listar();
    }
}
