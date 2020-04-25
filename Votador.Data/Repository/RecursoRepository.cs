using System;
using System.Collections.Generic;
using System.Text;
using Votador.Business.Interfaces;
using Votador.Business.Models;
using Votador.Data.Context;

namespace Votador.Data.Repositorio
{
    public class RecursoRepository : Repositorio<Recurso>, IRecursoRepositorio
    {
        public RecursoRepository(VotadorContext context) : base(context) { }
    }
}
