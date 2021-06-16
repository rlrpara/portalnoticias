using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;

namespace PortalNoticias.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>
    {
        private readonly IBaseRepository<Usuario> _baseRepository;
        public UsuarioRepository(IBaseRepository<Usuario> baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
