using Moq;
using System.Threading;
using System.Threading.Tasks;
using Votador.Business.Configuration;
using Xunit;

namespace Votador.Tests.Usuarios
{
    [Collection(nameof(UsuarioCollection))]
    public class UsuarioServiceTests
    {
        public UsuarioTestsFixture Fixture { get; set; }

        public UsuarioServiceTests(UsuarioTestsFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact(DisplayName = "Incluir Novo Usuario Valido")]
        [Trait("Categoria", "Testes de Servico de Usuario")]
        public async Task UsuarioService_NovoUsuario_UsuarioValido()
        {
            var usuarioService = Fixture.ObterUsuarioService();
            var usuario = Fixture.ObterUsuarioValido();

            await usuarioService.Incluir(usuario);

            Fixture.UsuarioRepositorioMock.Verify(u => u.Incluir(usuario), Times.Once);
            Fixture.MediatorMock.Verify(m => m.Publish(
                It.IsAny<NotificacaoTeste>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Incluir Novo Usuario Invalido")]
        [Trait("Categoria", "Testes de Servico de Usuario")]
        public async Task UsuarioService_NovoUsuario_UsuarioInvalido()
        {
            var usuarioService = Fixture.ObterUsuarioService();
            var usuario = Fixture.ObterUsuarioInvalido();

            await usuarioService.Incluir(usuario);

            Fixture.UsuarioRepositorioMock.Verify(u => u.Incluir(usuario), Times.Never);
            Fixture.MediatorMock.Verify(m => m.Publish(
                It.IsAny<NotificacaoTeste>(), CancellationToken.None), Times.Never);
        }
    }
}
