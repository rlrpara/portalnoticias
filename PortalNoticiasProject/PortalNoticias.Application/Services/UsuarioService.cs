using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PortalNoticias.Application.Services
{
    public class UsuarioService : BaseService
    {
        public UsuarioService(IBaseRepository repositorio):
            base(repositorio)
        {
        }

        public List<Usuario> GetAll()
        {
            try
            {
                return _baseRepository.BuscarTodosPorQuery<Usuario>("").Where(x => !x.IsDelete).ToList();
            }
            catch (Exception Ex)
            {
                throw;
            }
        }
    }
}
