using AutoMapper;
using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;
using PortalNoticias.Services.Interfaces;
using PortalNoticias.Services.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PortalNoticias.Services.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        #region Propriedades Privadas
        private IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Construtor
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
            : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        #endregion

        #region Métodos Privados
        private UsuarioViewModel RetornaUsuarioViewModel(Usuario usuario)
        {
            return (usuario != null ? _mapper.Map<UsuarioViewModel>(usuario) : null);
        }

        #endregion

        #region Métodos Públicos
        public List<UsuarioViewModel> GetAll()
        {
            try
            {
                return _mapper.Map<List<UsuarioViewModel>>(_usuarioRepository.BuscarTodosPorQueryGerador<Usuario>("").ToList());
            }
            catch
            {
                return default(dynamic);
            }
        }

        public UsuarioViewModel GetById(int id)
        {
            try
            {
                return RetornaUsuarioViewModel(_usuarioRepository.BuscarTodosPorId<Usuario>(id));
            }
            catch
            {
                return default(dynamic);
            }
        }

        #endregion
    }
}
