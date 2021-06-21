using PortalNoticias.Infra.CrossCutting.Util.ExtensionMethods;
using Xunit;

namespace PortalNoticias.Test.PortalNoticias.Infra.UtilTest.StringExtensionsTests
{
    [Trait("ExtensionMethods", "StringExtensions")]
    public class StringExtensionsTest
    {
        [Fact(DisplayName = "Deve retornar verdadeiro quando numerico")]
        public void DeveRetornarVerdadeiroQuandoNumerico()
        {
            Assert.Equal("12455", "A1d2@c45FVvfd5".ApenasNumeros());
        }
    }
}
