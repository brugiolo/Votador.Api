using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Votador.Business.Models;

namespace Votador.Business.Interfaces
{
    public interface IVotoService : IDisposable
    {
        Task Incluir(Voto entidade);
        Task<Voto> Obter(int id);
        Task Atualizar(Voto entidade);
        Task Deletar(int id);
        Task<List<Voto>> Listar();
    }
}
