using PortalNoticias.Application.ViewModels;
using PortalNoticias.Domain.Interfaces;
using System.Collections.Generic;

namespace PortalNoticias.Application.Services
{
    public class UsuarioService : BaseService
    {
        public UsuarioService(IBaseRepository repositorio):
            base(repositorio)
        {
        }

        public List<UsuarioViewModel> GetAll()
        {
            return null;
        }
    }
}
