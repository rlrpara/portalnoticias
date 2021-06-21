using PortalNoticias.Infra.CrossCutting.Util.ExtensionMethods;
using Xunit;

namespace PortalNoticias.Test.PortalNoticias.Infra.UtilTest.StringExtensionsTests
{
    [Trait("ExtensionMethods", "StringExtensions")]
    public class StringExtensionsTest
    {
        [Fact(DisplayName = "Deve retornar apenas numeros de uma string")]
        public void DeveRetornarApenasNumerosUmaString()
        {
            Assert.Equal("12455", "A1d2@c45FVvfd5".ApenasNumeros());
        }

        [Fact(DisplayName = "Deve retornar apenas vazio quando nao informado numeros")]
        public void DeveRetornarVazioQuandoNaoInformadoNumeros()
        {
            Assert.Equal("", "Ad@cFVvfd".ApenasNumeros());
        }
    }
}
