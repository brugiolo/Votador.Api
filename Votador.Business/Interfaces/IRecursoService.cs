using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Votador.Business.Models;

namespace Votador.Business.Interfaces
{
    public interface IRecursoService : IDisposable
    {
        Task Incluir(Recurso entidade);
        Task<Recurso> Obter(int id);
        Task Atualizar(Recurso entidade);
        Task Deletar(int id);
        Task<List<Recurso>> Listar();
    }
}