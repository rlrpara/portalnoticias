using AutoMapper;
using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;
using PortalNoticias.Services.ViewModels;

namespace PortalNoticias.Services.Services
{
    public class CategoriaService : BaseService<Categoria>
    {
        private readonly IBaseRepository<Categoria> _repository;
        private readonly IMapper _mapper;

        public CategoriaService(IBaseRepository<Categoria> baseRepository, IMapper mapper) : base(baseRepository)
        {
            _repository = baseRepository;
            _mapper = mapper;
        }

        public bool Inserir(CategoriaViewModel entity)
        {
            return _repository.Insert(_mapper.Map<Categoria>(entity));
        }

        public bool Atualizar(UsuarioViewModel entity)
        {
            return _repository.Update(_mapper.Map<Categoria>(entity));
        }
    }
}
