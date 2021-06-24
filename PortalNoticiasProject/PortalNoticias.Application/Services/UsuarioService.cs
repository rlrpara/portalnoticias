using AutoMapper;
using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;
using PortalNoticias.Infra.CrossCutting.Auth.Services;
using PortalNoticias.Infra.CrossCutting.Util.ExtensionMethods;
using PortalNoticias.Services.Interfaces;
using PortalNoticias.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace PortalNoticias.Services.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        #region Propriedades Privadas
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Construtor
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
            : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        #endregion

        #region Métodos Públicos
        public List<UsuarioViewModel> GetAll() => _mapper.Map<List<UsuarioViewModel>>(_usuarioRepository.BuscarTodosPorQueryGerador<Usuario>(""));

        public UsuarioViewModel GetById(string id)
        {
            if (!id.IsNumeric())
                throw new ArgumentException("Código de Usuário inválido");

            return (string.IsNullOrWhiteSpace(id) ? null : _mapper.Map<UsuarioViewModel>(_usuarioRepository.BuscarTodosPorId<Usuario>(int.Parse(id))));
        }

        public bool Post(UsuarioViewModel usuarioViewModel)
        {
            if (usuarioViewModel.Codigo != 0)
                throw new ArgumentException("O Código do Usuário deve ser nullo");

            Validator.ValidateObject(usuarioViewModel, new ValidationContext(usuarioViewModel), true);

            return (_usuarioRepository.Adicionar(_mapper.Map<Usuario>(usuarioViewModel)) > 0);
        }

        public bool Put(UsuarioViewModel usuarioViewModel)
        {
            if (usuarioViewModel.Codigo == 0)
                throw new ArgumentException("Código de Usuário inválido");

            return (_usuarioRepository.Atualizar(usuarioViewModel.Codigo, _mapper.Map<Usuario>(usuarioViewModel)) > 0);

        }

        public bool Delete(string id)
        {
            if (!id.IsNumeric())
                throw new ArgumentException("Código não informado.");

            return (_usuarioRepository.Excluir<Usuario>(int.Parse(id)) > 0);
        }

        public UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Senha))
                throw new ArgumentException("Email/Senha são necessários");
            try
            {
                var usuario = _usuarioRepository.BuscarTodosPorQueryGerador<Usuario>("").Where(x => !x.IsDelete && x.Email.ToLower().Contains(user.Email.ToLower())).FirstOrDefault();

                return (usuario == null ? null : new UserAuthenticateResponseViewModel(_mapper.Map<UsuarioViewModel>(usuario), TokenService.GenerateToken(usuario)));
            }
            catch (Exception Ex)
            {
                throw new ArgumentException($"Código de Usuário inválido: {Ex.Message}");
            }
        }

        #endregion
    }
}
