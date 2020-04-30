using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Votador.Api.ViewModels;
using Votador.Business.Interfaces;
using Votador.Business.Models;

namespace Votador.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, IUsuarioService usuarioService, IMapper mapper) : base()
        {
            _usuarioRepositorio = usuarioRepositorio;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UsuarioViewModel>> Listar()
        {
            var usuarioViewModel = await _usuarioService.Listar();

            return _mapper.Map<IEnumerable<UsuarioViewModel>>(usuarioViewModel);
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioViewModel>> Obter(int id)
        {
            var usuarioViewModel = await _usuarioService.Obter(id);

            if (usuarioViewModel == null)
                return NotFound();

            return _mapper.Map<UsuarioViewModel>(usuarioViewModel);
        }

        // POST: api/Usuario
        [HttpPost]
        public async Task<ActionResult<UsuarioViewModel>> Incluir(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var usuario = _mapper.Map<Usuario>(usuarioViewModel);

            var usuarioJaExistente = await _usuarioRepositorio.ObterUsuarioLogin(usuario.Email) != null;
            if (usuarioJaExistente)
                return BadRequest("Já existe um usuário cadastrado com esse e-mail.");

            await _usuarioService.Incluir(usuario);

            usuarioViewModel.Id = usuario.Id;
            usuarioViewModel.Senha = usuario.Senha;

            return Ok(usuarioViewModel);
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Atualizar(int id, UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid || id != usuarioViewModel.Id) 
                return BadRequest();

            var usuarioAtualizacao = await _usuarioService.Obter(id);
            usuarioAtualizacao.Nome = usuarioViewModel.Nome;
            usuarioAtualizacao.Email = usuarioViewModel.Email;
            usuarioAtualizacao.Senha = usuarioViewModel.Senha;
            usuarioAtualizacao.Ativo = usuarioViewModel.Ativo;

            await _usuarioService.Atualizar(_mapper.Map<Usuario>(usuarioAtualizacao));

            return Ok(usuarioViewModel);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioViewModel>> Delete(int id)
        {
            var usuario = await _usuarioService.Obter(id);
            var usuarioViewModel = _mapper.Map<UsuarioViewModel>(usuario);

            if (usuarioViewModel == null)
                return NotFound();

            await _usuarioService.Deletar(id);

            return Ok(usuarioViewModel);
        }

        // DELETE: api/Usuario/Desativar/5
        [HttpDelete("{id}/Desativar")]
        public async Task<ActionResult<UsuarioViewModel>> Desativar(int id)
        {
            var usuario = await _usuarioService.Obter(id);
            if (usuario== null)
                return NotFound();

            usuario.Ativo = false;
            await _usuarioService.Atualizar(usuario);

            return Ok(_mapper.Map<UsuarioViewModel>(usuario));
        }
    }
}
