using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;

namespace PortalNoticias.Infra.Data.Repositories
{
    public class MateriaRepository : BaseRepository<Materia>, IMateriaRepository
    {
        private readonly BaseRepository<Materia> _baseRepository;
        public MateriaRepository(BaseRepository<Materia> baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
