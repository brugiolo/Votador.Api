using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Votador.Business.Models;

namespace Votador.Business.Interfaces
{
    public interface IRepositorio<TEntidade> : IDisposable where TEntidade : Entidade
    {
        Task Incluir(TEntidade entidade);
        Task<TEntidade> Obter(int id);
        Task Atualizar(TEntidade entidade);
        Task Deletar(int id);
        Task<List<TEntidade>> Listar();
        Task<int> SalvarAlteracoes();
    }
}
