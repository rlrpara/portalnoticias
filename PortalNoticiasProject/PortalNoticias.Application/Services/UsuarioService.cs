using AutoMapper;
using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;
using PortalNoticias.Infra.CrossCutting.Auth.Services;
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
                return (id == 0 ? null : _mapper.Map<UsuarioViewModel>(_usuarioRepository.BuscarTodosPorId<Usuario>(id)));
            }
            catch
            {
                return default(dynamic);
            }
        }

        public bool Post(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                return (_usuarioRepository.Adicionar(_mapper.Map<Usuario>(usuarioViewModel)) > 0);
            }
            catch
            {
                return default(dynamic);
            }
        }

        public bool Put(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                if(_usuarioRepository.BuscarTodosPorId<Usuario>(usuarioViewModel.Codigo) != null)
                    return (_usuarioRepository.Atualizar(usuarioViewModel.Codigo, _mapper.Map<Usuario>(usuarioViewModel)) > 0);

                return false;
            }
            catch
            {
                return default(dynamic);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                if (_usuarioRepository.BuscarTodosPorId<Usuario>(id) != null)
                    return (_usuarioRepository.Excluir<Usuario>(id) > 0);

                return false;
            }
            catch
            {
                return default(dynamic);
            }
        }

        public UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel user)
        {
            var usuario = _usuarioRepository.BuscarTodosPorQueryGerador<Usuario>("") .Where(x => !x.IsDelete && x.Email.ToLower().Contains(user.Email.ToLower())).FirstOrDefault();

            return (usuario == null ? null : new UserAuthenticateResponseViewModel(_mapper.Map<UsuarioViewModel>(usuario), TokenService.GenerateToken(usuario)));
        }

        #endregion
    }
}
