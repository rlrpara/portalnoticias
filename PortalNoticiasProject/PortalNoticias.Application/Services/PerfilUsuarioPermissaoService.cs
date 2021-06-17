using PortalNoticias.Application.Interfaces;
using PortalNoticias.Domain.Interfaces;

namespace PortalNoticias.Application.Services
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
