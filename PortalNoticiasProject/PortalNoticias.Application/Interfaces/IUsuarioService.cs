using PortalNoticias.Application.ViewModels;
using System.Collections.Generic;

namespace PortalNoticias.Application.Interfaces
{
    public interface IUsuarioService : IBaseService
    {
        List<UsuarioViewModel> GetAll();
    }
}
