using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Votador.Business.Configuration;
using Votador.Business.Interfaces;
using Votador.Business.Models;
using Votador.Business.Validations;

namespace Votador.Business.Services
{
    public class RecursoService : BaseService, IRecursoService
    {
        private readonly IRecursoRepositorio _recursoRepositorio;
        private readonly IMediator _mediator;

        public RecursoService(IRecursoRepositorio recursoRepositorio, IMediator mediator)
        {
            _recursoRepositorio = recursoRepositorio;
            _mediator = mediator;
        }

        public async Task Incluir(Recurso recurso)
        {
            if (!ExecutarValidacao(new RecursoValidacao(), recurso))
                return;

            recurso.DataCadastro = DateTime.Now;
            await _recursoRepositorio.Incluir(recurso);
            await _mediator.Publish(new NotificacaoTeste("RecursoService - Recurso incluído com sucesso."));
        }

        public async Task<Recurso> Obter(int id)
        {
            var usuario = await _recursoRepositorio.Obter(id);
            
            if (usuario != null) 
                await _mediator.Publish(new NotificacaoTeste("RecursoService - Recurso obtido com sucesso."));

            return usuario;
        }

        public async Task Atualizar(Recurso recurso)
        {
            if (!ExecutarValidacao(new RecursoValidacao(), recurso))
                return;

            await _recursoRepositorio.Atualizar(recurso);
            await _mediator.Publish(new NotificacaoTeste("RecursoService - Recurso atualizado com sucesso."));
        }

        public async Task Deletar(int id)
        {
            var usuario = await _recursoRepositorio.Obter(id);

            if (usuario != null)
            {
                await _recursoRepositorio.Deletar(id);
                await _mediator.Publish(new NotificacaoTeste("RecursoService - Recurso deletado com sucesso."));
            }
        }

        public async Task<List<Recurso>> Listar()
        {
            var usuarios = await _recursoRepositorio.Listar();
            
            if (usuarios.Count > 0)
                await _mediator.Publish(new NotificacaoTeste("RecursoService - Recursos listados com sucesso."));

            return usuarios;
        }

        public void Dispose()
        {
            _recursoRepositorio?.Dispose();
        }
    }
}
