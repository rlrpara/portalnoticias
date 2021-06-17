using PortalNoticias.Services.Interfaces;
using PortalNoticias.Domain.Interfaces;

namespace PortalNoticias.Services.Services
{
    public class PerfilUsuarioService : BaseService, IPerfilUsuarioService
    {
        private readonly IPerfilUsuarioRepository _perfilUsuarioRepository;

        public PerfilUsuarioService(IPerfilUsuarioRepository perfilUsuarioRepository)
            : base(perfilUsuarioRepository)
        {
            _perfilUsuarioRepository = perfilUsuarioRepository;
        }
    }
}
