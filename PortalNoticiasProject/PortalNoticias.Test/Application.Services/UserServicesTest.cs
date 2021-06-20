using AutoMapper;
using Moq;
using PortalNoticias.Domain.Interfaces;
using PortalNoticias.Services.Services;
using PortalNoticias.Services.ViewModels;
using System;
using Xunit;

namespace PortalNoticias.Test.Application.Services
{
    [Trait("Service", "UsuarioService")]
    public class UserServicesTest
    {
        private UsuarioService _usuarioService;

        public UserServicesTest()
        {
            _usuarioService = new UsuarioService(new Mock<IUsuarioRepository>().Object, new Mock<IMapper>().Object);
        }

        [Fact(DisplayName = "Deve invalidar ao enviar Id via método Post")]
        public void DeveInvalidarEnviarIDViaMetodoPost()
        {
            var exception = Assert.Throws<ArgumentException>(() => _usuarioService.Post(new UsuarioViewModel { Codigo = 1 }));

            Assert.Equal("O Código do Usuário deve ser nullo", exception.Message);
        }

        [Fact(DisplayName = "Deve invalidar ao enviar id vazia ou nulla via GetById")]
        public void DeveInvalidarEnviarIDVaziaNUlaViaGetById()
        {
            Exception exception = Assert.Throws<ArgumentException>(() => _usuarioService.GetById(""));

            Assert.Equal("Código de Usuário inválido", exception.Message);
        }

        [Fact(DisplayName = "Deve invalidar ao enviar id vazia ou nulla via Put")]
        public void DeveInvalidarEnviarIDVaziaNulaViaPut()
        {
            Exception exception = Assert.Throws<ArgumentException>(() => _usuarioService.Put(new UsuarioViewModel()));

            Assert.Equal("Código de Usuário inválido", exception.Message);
        }

        [Fact(DisplayName = "Deve invalidar ao enviar id vazia ou nulla via Delete")]
        public void DeveInvalidarEnviarIDVaziaNulaViaDelete()
        {
            Exception exception = Assert.Throws<ArgumentException>(() => _usuarioService.Delete(""));

            Assert.Equal("Código não informado.", exception.Message);
        }

        [Fact(DisplayName = "Deve invalidar ao enviar dados da autenticação vazia")]
        public void DeveInvalidarEnviarDadosAutenticacaoVazia()
        {
            Exception exception = Assert.Throws<ArgumentException>(() => _usuarioService.Authenticate(new UserAuthenticateRequestViewModel()));

            Assert.Equal("Email/Senha são necessários", exception.Message);
        }
    }
}
