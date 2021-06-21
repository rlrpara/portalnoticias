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
            Assert.True("1".IsNumeric());
        }

        [Fact(DisplayName = "Deve retornar falso quando não numerico")]
        public void DeveRetornarFalsoQuandoNaoNumerico()
        {
            Assert.False("N".IsNumeric());
        }

        [Fact(DisplayName = "Deve retornar falso quando não informado")]
        public void DeveRetornarFalsoQuandoNaoInformado()
        {
            Assert.False("".IsNumeric());
        }
    }
}
