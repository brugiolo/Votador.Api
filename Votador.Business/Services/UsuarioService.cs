using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using Votador.Business.Configuration;
using Votador.Business.Interfaces;
using Votador.Business.Models;
using Votador.Business.Validations;

namespace Votador.Business.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepositorio _usuarioRepository;
        private readonly IMediator _mediator;

        public UsuarioService(IUsuarioRepositorio usuarioRepository, IMediator mediator)
        {
            _usuarioRepository = usuarioRepository;
            _mediator = mediator;
        }

        public async Task Incluir(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidacao(), usuario))
                return;
            
            await _usuarioRepository.Incluir(usuario);
            await _mediator.Publish(new NotificacaoTeste("UsuarioService - Usuário incluído com sucesso."));
        }

        public async Task<Usuario> Obter(int id)
        {
            var usuario = await _usuarioRepository.Obter(id);
            
            if (usuario != null) 
                await _mediator.Publish(new NotificacaoTeste("UsuarioService - Usuário obtido com sucesso."));

            return usuario;
        }

        public async Task Atualizar(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidacao(), usuario))
                return;

            await _usuarioRepository.Atualizar(usuario);
            await _mediator.Publish(new NotificacaoTeste("UsuarioService - Usuário atualizado com sucesso."));
        }

        public async Task Deletar(int id)
        {
            var usuario = await _usuarioRepository.Obter(id);

            if (usuario != null)
            {
                await _usuarioRepository.Deletar(id);
                await _mediator.Publish(new NotificacaoTeste("UsuarioService - Usuário deletado com sucesso."));
            }
        }

        public async Task<List<Usuario>> Listar()
        {
            var usuarios = await _usuarioRepository.Listar();
            
            if (usuarios.Count > 0)
                await _mediator.Publish(new NotificacaoTeste("UsuarioService - Usuários listados com sucesso."));

            return usuarios;
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}
