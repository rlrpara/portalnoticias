using PortalNoticias.Application.Interfaces;
using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;

namespace PortalNoticias.Application.Services
{
    public class MunicipioService : BaseService<Municipio>, IMunicipioService
    {
        private readonly IMunicipioRepository _municipioRepository;

        public MunicipioService(IMunicipioRepository municipioRepository)
            : base(municipioRepository)
        {
            _municipioRepository = municipioRepository;
        }
    }
}
