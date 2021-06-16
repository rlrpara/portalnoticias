using PortalNoticias.Domain.Entities;
using System.Collections.Generic;

namespace PortalNoticias.Application.Interfaces
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        List<Usuario> GetAll();
    }
}
