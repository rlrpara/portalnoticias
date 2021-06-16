using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;

namespace PortalNoticias.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly BaseRepository<Usuario> _baseRepository;
        public UsuarioRepository(BaseRepository<Usuario> baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
