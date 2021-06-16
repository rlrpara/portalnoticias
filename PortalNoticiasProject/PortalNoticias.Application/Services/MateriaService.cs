using PortalNoticias.Application.Interfaces;
using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;

namespace PortalNoticias.Application.Services
{
    public class MateriaService : BaseService<Materia>, IMateriaService
    {
        private readonly IMateriaRepository _materiaRepository;

        public MateriaService(IMateriaRepository materiaRepository)
            :base (materiaRepository)
        {
            _materiaRepository = materiaRepository;
        }
    }
}
