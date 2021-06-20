using PortalNoticias.Services.ViewModels;
using System.Collections.Generic;

namespace PortalNoticias.Services.Interfaces
{
    public interface IUsuarioService : IBaseService
    {
        List<UsuarioViewModel> GetAll();
        UsuarioViewModel GetById(string id);
        bool Post(UsuarioViewModel usuarioViewModel);
        bool Put(UsuarioViewModel usuarioViewModel);
        bool Delete(string id);
        UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel user);
    }
}
