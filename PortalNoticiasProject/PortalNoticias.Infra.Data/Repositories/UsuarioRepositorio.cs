using PortalNoticias.Domain.Interfaces;

namespace PortalNoticias.Infra.Data.Repositories
{
    public class UsuarioRepositorio : BaseRepository
    {
        private readonly IBaseRepository _baseRepository;
        public UsuarioRepositorio(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
