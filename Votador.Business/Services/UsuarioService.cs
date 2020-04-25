using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Votador.Business.Interfaces;
using Votador.Business.Models;
using Votador.Business.Validations;

namespace Votador.Business.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepositorio _usuarioRepository;
        private readonly IMediator _mediator;

        public UsuarioService(IUsuarioRepositorio usuarioRepository, IMediator mediator) : base()
        {
            _usuarioRepository = usuarioRepository;
            _mediator = mediator;
        }

        public async Task Incluir(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidacao(), usuario))
                return;
            
            await _usuarioRepository.Incluir(usuario);
            await _mediator.Publish("Service - Usuário incluído com sucesso.");
        }

        public async Task<Usuario> Obter(int id)
        {
            return await _usuarioRepository.Obter(id);
        }

        public async Task Atualizar(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidacao(), usuario))
                return;

            await _usuarioRepository.Atualizar(usuario);
        }

        public Task Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Usuario>> Listar()
        {
            return await _usuarioRepository.Listar();
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}
