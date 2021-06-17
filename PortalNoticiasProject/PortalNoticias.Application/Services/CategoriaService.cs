using PortalNoticias.Application.Interfaces;
using PortalNoticias.Domain.Interfaces;

namespace PortalNoticias.Application.Services
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
