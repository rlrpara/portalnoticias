using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;

namespace PortalNoticias.Infra.Data.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        private readonly BaseRepository<Categoria> _baseRepository;
        public CategoriaRepository(BaseRepository<Categoria> baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
