using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PortalNoticias.Infra.Util.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string RemoveAcentos(this string valor)
        {
            return new string(valor.Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray()).ToUpper();
        }

        public static string ApenasNumeros(this string valor)
        {
            return new Regex(@"[^0-9a]").Replace(valor, "");
        }
    }
}
