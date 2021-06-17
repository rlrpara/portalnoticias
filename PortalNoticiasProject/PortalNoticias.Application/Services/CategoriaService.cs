using PortalNoticias.Services.Interfaces;
using PortalNoticias.Domain.Interfaces;

namespace PortalNoticias.Services.Services
{
    public  class CategoriaService : BaseService, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
            : base(categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
    }
}
