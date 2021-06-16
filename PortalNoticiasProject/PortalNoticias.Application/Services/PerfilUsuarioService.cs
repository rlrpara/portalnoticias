using PortalNoticias.Application.Interfaces;
using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;

namespace PortalNoticias.Application.Services
{
    public class PerfilUsuarioService : BaseService<PerfilUsuario>, IPerfilUsuarioService
    {
        private readonly IPerfilUsuarioRepository _perfilUsuarioRepository;

        public PerfilUsuarioService(IPerfilUsuarioRepository perfilUsuarioRepository)
            : base(perfilUsuarioRepository)
        {
            _perfilUsuarioRepository = perfilUsuarioRepository;
        }
    }
}
