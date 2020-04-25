using AutoMoq;
using Bogus;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Votador.Business.Interfaces;
using Votador.Business.Models;
using Votador.Business.Services;
using Xunit;
using Unity.Extension;
using Votador.Api.Controllers;

namespace Votador.Tests.Usuarios
{
    [CollectionDefinition(nameof(UsuarioCollection))]
    public class UsuarioCollection : ICollectionFixture<UsuarioTestsFixture>
    {
    }

    public class UsuarioTestsFixture : IDisposable
    {
        //public Mock<IUsuarioController> UsuarioControllerMock { get; set; }
        public Mock<IUsuarioRepositorio> UsuarioRepositorioMock { get; set; }
        public Mock<IUsuarioService> UsuarioServiceMock { get; set; }
        public Mock<IMediator> MediatorMock { get; set; }

        public UsuarioService ObterUsuarioService()
        {
            var autoMoqer = new AutoMoqer();
            autoMoqer.Create<UsuarioService>();

            var UsuarioService = autoMoqer.Resolve<UsuarioService>();

            UsuarioRepositorioMock = autoMoqer.GetMock<IUsuarioRepositorio>();
            UsuarioServiceMock = autoMoqer.GetMock<IUsuarioService>();
            MediatorMock = autoMoqer.GetMock<IMediator>();

            return UsuarioService;
        }

        public Usuario ObterUsuarioValido()
        {
            var usuario = CriarUsuariosFake(1, true, true);

            return usuario.First();
        }

        public Usuario ObterUsuarioInvalido()
        {
            var usuario = CriarUsuariosFake(1, true, false);

            return usuario.First();
        }

        public IEnumerable<Usuario> ObterUsuariosVariados()
        {
            var usuarios = new List<Usuario>();

            var usuariosAtivos = CriarUsuariosFake(10, true, true);
            var usuariosInativos = CriarUsuariosFake(10, false, true);

            usuarios.AddRange(usuariosAtivos);
            usuarios.AddRange(usuariosInativos);

            return usuarios;
        }

        private static IEnumerable<Usuario> CriarUsuariosFake(int quantidade, bool ativo, bool valido)
        {
            var faker = new Faker<Usuario>("pt_BR")
                .CustomInstantiator(u => new Usuario{
                    Nome = string.Format("{0} {1}", u.Name.FirstName(), u.Name.LastName()),
                    Email = (valido ? u.Internet.ExampleEmail() : null),
                    Senha = u.Internet.Password(8),
                    Ativo = ativo,
                    TipoDeUsuario = 2
                });

            return faker.Generate(quantidade);
        }

        public void Dispose()
        {
            //nada a fazer...
        }
    }

}
