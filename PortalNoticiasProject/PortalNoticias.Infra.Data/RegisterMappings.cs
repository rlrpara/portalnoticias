using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using PortalNoticias.Infra.Data.Mappers;

namespace PortalNoticias.Infra.Data
{
    public static class RegisterMappings
    {
        public static void Register()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new MapCategoria());
                config.ForDommel();
            });
        }
    }
}
