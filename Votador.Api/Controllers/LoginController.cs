using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Votador.Api.ViewModels;
using Votador.Business.Interfaces;

namespace Votador.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService) : base()
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("Autenticar")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginViewModel>> Autenticar([FromBody]LoginViewModel loginViewModel)
        {
            var usuario = await _usuarioService.Autenticar(loginViewModel.Email, loginViewModel.Senha);

            if (usuario == null)
                return BadRequest(new { message = "Usuário e/ou senha inválidos" });

            loginViewModel.Token = usuario.Token;

            return Ok(loginViewModel);
        }
    }
}