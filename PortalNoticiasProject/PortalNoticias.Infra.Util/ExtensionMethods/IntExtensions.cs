namespace PortalNoticias.Infra.CrossCutting.Util.ExtensionMethods
{
    public static class IntExtensions
    {
        public static bool IsNumeric(this string valor)
        {
            return (int.TryParse(valor, out int convertido));
        }
    }
}
