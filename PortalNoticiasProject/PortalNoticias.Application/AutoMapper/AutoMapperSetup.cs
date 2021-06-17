using AutoMapper;
using PortalNoticias.Domain.Entities;
using PortalNoticias.Services.ViewModels;

namespace PortalNoticias.Services.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModelToDomain
            CreateMap<UsuarioViewModel, Usuario>();
            #endregion

            #region DomainToViewModel
            CreateMap<Usuario, UsuarioViewModel>();
            #endregion
        }
    }
}
