using PortalNoticias.Domain.Interfaces;

namespace PortalNoticias.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository
    {
        private readonly IBaseRepository _baseRepository;
        public UsuarioRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
