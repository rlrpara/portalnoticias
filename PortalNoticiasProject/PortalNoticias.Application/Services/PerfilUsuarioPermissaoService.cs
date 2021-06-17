using PortalNoticias.Services.Interfaces;
using PortalNoticias.Domain.Interfaces;

namespace PortalNoticias.Services.Services
{
    public class PerfilUsuarioPermissaoService : BaseService, IPerfilUsuarioPermissaoService
    {
        private readonly IPerfilUsuarioPermissaoRepository _perfilUsuarioPermissaoRepository;

        public PerfilUsuarioPermissaoService(IPerfilUsuarioPermissaoRepository perfilUsuarioPermissaoRepository)
            : base(perfilUsuarioPermissaoRepository)
        {
            _perfilUsuarioPermissaoRepository = perfilUsuarioPermissaoRepository;
        }
    }
}
