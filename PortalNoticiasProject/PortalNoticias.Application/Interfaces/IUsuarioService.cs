using PortalNoticias.Services.ViewModels;
using System.Collections.Generic;

namespace PortalNoticias.Services.Interfaces
{
    public interface IUsuarioService : IBaseService
    {
        List<UsuarioViewModel> GetAll();
        UsuarioViewModel GetById(int id);
    }
}
