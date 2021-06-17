using PortalNoticias.Services.Interfaces;
using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using PortalNoticias.Services.ViewModels;
using PortalNoticias.Infra.Util.ExtensionMethods;

namespace PortalNoticias.Services.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
            : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

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
    }
}
