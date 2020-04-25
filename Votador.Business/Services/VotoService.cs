using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Votador.Business.Interfaces;
using Votador.Business.Models;
using Votador.Business.Validations;

namespace Votador.Business.Services
{
    public class VotoService : BaseService, IVotoService
    {
        private readonly IVotoRepositorio _votoRepository;
        private readonly IMediator _mediator;

        public VotoService(IVotoRepositorio votoRepository, IMediator mediator) : base()
        {
            _votoRepository = votoRepository;
            _mediator = mediator;
        }

        public async Task Incluir(Voto voto)
        {
            if (!ExecutarValidacao(new VotoValidacao(), voto))
                return;
            
            await _votoRepository.Incluir(voto);
            await _mediator.Publish("VotoService - Voto incluído com sucesso.");
        }

        public async Task<Voto> Obter(int id)
        {
            var voto = await _votoRepository.Obter(id);
            
            if (voto != null) 
                await _mediator.Publish("VotoService - Voto obtido com sucesso.");

            return voto;
        }

        public async Task Atualizar(Voto voto)
        {
            if (!ExecutarValidacao(new VotoValidacao(), voto))
                return;

            await _votoRepository.Atualizar(voto);
            await _mediator.Publish("VotoService - Voto atualizado com sucesso.");
        }

        public async Task Deletar(int id)
        {
            var voto = await _votoRepository.Obter(id);

            if (voto != null)
            {
                await _votoRepository.Deletar(id);
                await _mediator.Publish("VotoService - Voto deletado com sucesso.");
            }
        }

        public async Task<List<Voto>> Listar()
        {
            var votos = await _votoRepository.Listar();
            
            if (votos.Count > 0)
                await _mediator.Publish("VotoService - Votos listados com sucesso.");

            return votos;
        }

        public void Dispose()
        {
            _votoRepository?.Dispose();
        }
    }
}
