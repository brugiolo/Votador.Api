using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Votador.Business.Interfaces;
using Votador.Business.Models;
using Votador.Business.Validations;

namespace Votador.Business.Services
{
    public class RecursoService : BaseService, IRecursoService
    {
        private readonly IRecursoRepositorio _recursoRepository;
        private readonly IMediator _mediator;

        public RecursoService(IRecursoRepositorio recursoRepository, IMediator mediator) : base()
        {
            _recursoRepository = recursoRepository;
            _mediator = mediator;
        }

        public async Task Incluir(Recurso recurso)
        {
            if (!ExecutarValidacao(new RecursoValidacao(), recurso))
                return;
            
            await _recursoRepository.Incluir(recurso);
            await _mediator.Publish("RecursoService - Recurso incluído com sucesso.");
        }

        public async Task<Recurso> Obter(int id)
        {
            var usuario = await _recursoRepository.Obter(id);
            
            if (usuario != null) 
                await _mediator.Publish("RecursoService - Recurso obtido com sucesso.");

            return usuario;
        }

        public async Task Atualizar(Recurso recurso)
        {
            if (!ExecutarValidacao(new RecursoValidacao(), recurso))
                return;

            await _recursoRepository.Atualizar(recurso);
            await _mediator.Publish("RecursoService - Recurso atualizado com sucesso.");
        }

        public async Task Deletar(int id)
        {
            var usuario = await _recursoRepository.Obter(id);

            if (usuario != null)
            {
                await _recursoRepository.Deletar(id);
                await _mediator.Publish("RecursoService - Recurso deletado com sucesso.");
            }
        }

        public async Task<List<Recurso>> Listar()
        {
            var usuarios = await _recursoRepository.Listar();
            
            if (usuarios.Count > 0)
                await _mediator.Publish("RecursoService - Recursos listados com sucesso.");

            return usuarios;
        }

        public void Dispose()
        {
            _recursoRepository?.Dispose();
        }
    }
}
