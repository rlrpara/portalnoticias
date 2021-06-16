using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;

namespace PortalNoticias.Infra.Data.Repositories
{
    public class PerfilUsuarioRepository : BaseRepository<PerfilUsuario>, IPerfilUsuarioRepository
    {
        private readonly BaseRepository<PerfilUsuario> _baseRepository;
        public PerfilUsuarioRepository(BaseRepository<PerfilUsuario> baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
