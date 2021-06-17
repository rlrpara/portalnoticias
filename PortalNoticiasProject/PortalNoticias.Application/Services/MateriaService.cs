using PortalNoticias.Services.Interfaces;
using PortalNoticias.Domain.Interfaces;

namespace PortalNoticias.Services.Services
{
    public class MateriaService : BaseService, IMateriaService
    {
        private readonly IMateriaRepository _materiaRepository;

        public MateriaService(IMateriaRepository materiaRepository)
            :base (materiaRepository)
        {
            _materiaRepository = materiaRepository;
        }
    }
}
