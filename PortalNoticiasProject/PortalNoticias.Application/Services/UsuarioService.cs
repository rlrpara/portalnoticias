using PortalNoticias.Services.Interfaces;
using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using PortalNoticias.Services.ViewModels;
using PortalNoticias.Infra.Util.ExtensionMethods;
using System;

namespace PortalNoticias.Services.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        #region Propriedades Privadas
        private IUsuarioRepository _usuarioRepository;

        #endregion

        #region Construtor
        public UsuarioService(IUsuarioRepository usuarioRepository)
            : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        #endregion

        #region Métodos Privados
        private UsuarioViewModel RetornaUsuarioViewModel(Usuario usuario)
        {
            if (usuario != null)
                return new UsuarioViewModel() { Codigo = usuario.Codigo, Email = usuario.Email, Nome = usuario.Nome };

            return null;
        }

        #endregion

        #region Métodos Públicos
        public List<UsuarioViewModel> GetAll()
        {
            try
            {
                var listUsuariosViewModel = new List<UsuarioViewModel>();

                foreach (var item in _usuarioRepository.BuscarTodosPorQueryGerador<Usuario>("").ToList())
                    listUsuariosViewModel.Add(new UsuarioViewModel { Codigo = item.Codigo, Email = item.Email, Nome = item.Nome.RemoveAcentos() });

                return listUsuariosViewModel;
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
