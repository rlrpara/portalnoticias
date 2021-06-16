using PortalNoticias.Application.Interfaces;
using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;

namespace PortalNoticias.Application.Services
{
    public class PerfilUsuarioPermissaoService : BaseService<PerfilUsuarioPermissao>, IPerfilUsuarioPermissaoService
    {
        private readonly IPerfilUsuarioPermissaoRepository _perfilUsuarioPermissaoRepository;

        public PerfilUsuarioPermissaoService(IPerfilUsuarioPermissaoRepository perfilUsuarioPermissaoRepository)
            : base(perfilUsuarioPermissaoRepository)
        {
            _perfilUsuarioPermissaoRepository = perfilUsuarioPermissaoRepository;
        }
    }
}
