using PortalNoticias.Application.Interfaces;
using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PortalNoticias.Application.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
            : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public List<Usuario> GetAll()
        {
            return _usuarioRepository.BuscarTodosPorQueryGerador<Usuario>("").ToList();
        }
    }
}
