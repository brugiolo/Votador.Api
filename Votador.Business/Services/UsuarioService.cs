using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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

        public async Task<Usuario> Autenticar(string email, string senha)
        {
            var usuario = await _usuarioRepository.ObterUsuarioLogin(email);

            if (usuario == null)
                return null;

            var usuarioValidado = Usuario.CompararHashMD5(senha, usuario.Senha);

            if (!usuarioValidado)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Usuario.SecretGuid);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim("Store", "user")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            usuario.Token = tokenHandler.WriteToken(token);

            return usuario;
        }

        public async Task Incluir(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidacao(), usuario))
                return;

            var senhaMd5 = Usuario.GerarSenhaGashMD5(usuario.Senha);
            usuario.Senha = senhaMd5;
            
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
