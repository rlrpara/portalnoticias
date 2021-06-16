using PortalNoticias.Application.Interfaces;
using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;
using System.Collections.Generic;

namespace PortalNoticias.Application.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
            : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public List<Usuario> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
