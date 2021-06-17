using PortalNoticias.Services.Interfaces;
using PortalNoticias.Domain.Interfaces;

namespace PortalNoticias.Services.Services
{
    public class MunicipioService : BaseService, IMunicipioService
    {
        private readonly IMunicipioRepository _municipioRepository;

        public MunicipioService(IMunicipioRepository municipioRepository)
            : base(municipioRepository)
        {
            _municipioRepository = municipioRepository;
        }
    }
}
