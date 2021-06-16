using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;

namespace PortalNoticias.Infra.Data.Repositories
{
    public class PerfilUsuarioPermissaoRepository : BaseRepository<PerfilUsuarioPermissao>, IPerfilUsuarioPermissaoRepository
    {
        private readonly BaseRepository<PerfilUsuarioPermissao> _baseRepository;
        public PerfilUsuarioPermissaoRepository(BaseRepository<PerfilUsuarioPermissao> baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
