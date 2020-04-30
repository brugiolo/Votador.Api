using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Votador.Business.Interfaces;
using Votador.Business.Models;
using Votador.Data.Context;

namespace Votador.Data.Repositorio
{
    public class Repositorio<TEntidade> : IRepositorio<TEntidade> where TEntidade : Entidade, new()
    {
        protected readonly VotadorContext Contexto;
        protected readonly DbSet<TEntidade> DbSet;

        public Repositorio(VotadorContext contexto)
        {
            Contexto = contexto;
            DbSet = contexto.Set<TEntidade>();
        }

        public virtual async Task Incluir(TEntidade entidade)
        {
            DbSet.Add(entidade);
            await SalvarAlteracoes();
        }

        public virtual async Task<TEntidade> Obter(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task Atualizar(TEntidade entidade)
        {
            DbSet.Update(entidade);
            await SalvarAlteracoes();
        }

        public virtual async Task Deletar(int id)
        {
            DbSet.Remove(DbSet.Find(id));
            await SalvarAlteracoes();
        }

        public virtual async Task<List<TEntidade>> Listar()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<int> SalvarAlteracoes()
        {
            return await Contexto.SaveChangesAsync();
        }

        public void Dispose()
        {
            Contexto?.Dispose();
        }
    }
}
