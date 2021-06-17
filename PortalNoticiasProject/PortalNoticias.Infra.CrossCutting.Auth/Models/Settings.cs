using System;

namespace PortalNoticias.Infra.CrossCutting.Auth.Models
{
    public static class Settings
    {
        public static string Secret = Environment.GetEnvironmentVariable("Secret");
    }
}
