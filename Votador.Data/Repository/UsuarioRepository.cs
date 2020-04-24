using System;
using System.Collections.Generic;
using System.Text;
using Votador.Business.Interfaces;
using Votador.Business.Models;
using Votador.Data.Context;

namespace Votador.Data.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(VotadorContext context) : base(context) { }
    }
}
