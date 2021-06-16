using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;

namespace PortalNoticias.Infra.Data.Repositories
{
    public class MunicipioRepository : BaseRepository<Municipio>, IMunicipioRepository
    {
        private readonly BaseRepository<Municipio> _baseRepository;
        public MunicipioRepository(BaseRepository<Municipio> baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
