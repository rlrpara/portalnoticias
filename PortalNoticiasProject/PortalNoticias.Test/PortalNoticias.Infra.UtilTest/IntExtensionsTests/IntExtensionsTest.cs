using PortalNoticias.Infra.CrossCutting.Util.ExtensionMethods;
using Xunit;

namespace PortalNoticias.Test.PortalNoticias.Infra.UtilTest.IntExtensionsTests
{
    [Trait("ExtensionMethods", "IntExtensions")]
    public class IntExtensionsTest
    {
        [Fact(DisplayName = "Deve retornar verdadeiro quando numerico")]
        public void DeveRetornarVerdadeiroQuandoNumerico()
        {
            var codigo = "1";

            Assert.True(codigo.IsNumeric());
        }

        [Fact(DisplayName = "Deve retornar falso quando não numerico")]
        public void DeveRetornarFalsoQuandoNaoNumerico()
        {
            var codigo = "N";

            Assert.False(codigo.IsNumeric());
        }

        [Fact(DisplayName = "Deve retornar falso quando não informado")]
        public void DeveRetornarFalsoQuandoNaoInformado()
        {
            var codigo = "";

            Assert.False(codigo.IsNumeric());
        }
    }
}
