using FluentAssertions;
using Xunit;

namespace Votador.Tests.Usuarios
{
    [Collection(nameof(UsuarioCollection))]
    public class UsuarioTests
    {
        public UsuarioTestsFixture Fixture { get; set; }

        public UsuarioTests(UsuarioTestsFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact(DisplayName = "Novo Usuario Valido")]
        [Trait("Categoria", "Testes de Usuario")]
        public void Usuario_NovoUsuario_UsuarioValido()
        {
            var usuario = Fixture.ObterUsuarioValido();
            var resultado = usuario.IsValid();

            resultado.Should().BeTrue();
            usuario.ValidationResult.Errors.Should().HaveCount(0);

            Assert.True(resultado);
            Assert.Equal(0, usuario.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "Novo Usuario Invalido")]
        [Trait("Categoria", "Testes de Usuario")]
        public void Usuario_NovoUsuario_UsuarioInvalido()
        {
            var usuario = Fixture.ObterUsuarioInvalido();
            var resultado = usuario.IsValid();

            resultado.Should().BeFalse();
            usuario.ValidationResult.Errors.Should().HaveCount(c => c > 0);

            Assert.False(resultado);
            Assert.NotEqual(0, usuario.ValidationResult.Errors.Count);
        }
    }
}
