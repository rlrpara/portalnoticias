using AutoMapper;
using Moq;
using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;
using PortalNoticias.Services.AutoMapper;
using PortalNoticias.Services.Services;
using PortalNoticias.Services.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace PortalNoticias.Test.Application.ServicesTest.UserServicesTests
{
    [Trait("Service", "UsuarioService")]
    public class UserServicesTest : UserServicesTestBase
    {
        #region Propriedades Privadas
        private UsuarioService _usuarioService;

        #endregion

        #region Construtor
        public UserServicesTest()
        {
            var moqUsuarioRepositorio = new Mock<IUsuarioRepository>().Object;
            var moqMapper = new Mock<IMapper>().Object;
            _usuarioService = new UsuarioService(moqUsuarioRepositorio, moqMapper);
        }

        #endregion

        #region Métodos Privados
        private Mapper ObterMapperConfig()
        {
            var autoMapperProfile = new AutoMapperSetup();
            var configuration = new MapperConfiguration(x => x.AddProfile(autoMapperProfile));
            return new Mapper(configuration);
        }
        #endregion

        #region Valida Codigo Obrigatório
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

        #endregion

        #region Valida Objetos Corretos
        [Fact(DisplayName = "Deve enviar um objeto válido via Post")]
        public void DeveEnviarUmObjetoValidoViaPost()
        {
            Assert.False(_usuarioService.Post(ObterNovoUsuario()));
        }

        [Fact(DisplayName = "Deve retornar uma lista maior que 0 via GetAll")]
        public void DeveRetornarListaMaiorQueZeroViaGetAll()
        {
            var usuarioRepository = new Mock<IUsuarioRepository>();

            usuarioRepository.Setup(x => x.BuscarTodosPorQueryGerador<Usuario>("")).Returns(ObterListaUsuarios());

            var resultado = new UsuarioService(usuarioRepository.Object, ObterMapperConfig()).GetAll();

            Assert.True(resultado.Count > 0);
        }

        [Fact(DisplayName = "Deve retornar um usuario quando informado seu código válido via GetById")]
        public void DeveRetornarUmUsuarioQuandoInformadoSeuCodigoValidoViaGetById()
        {
            var usuarioRepository = new Mock<IUsuarioRepository>();

            usuarioRepository.Setup(x => x.BuscarTodosPorId<Usuario>(1)).Returns(ObterUsuario1());

            var usuario = new UsuarioService(usuarioRepository.Object, ObterMapperConfig()).GetById("1");

            Assert.Equal("RODRIGO RIBEIRO", usuario.Nome);
        }

        #endregion

        #region Valida Campos Obrigatórios
        [Fact(DisplayName = "Deve invalidar quando não enviar um campo obrigatório via Post")]
        public void DeveInvalidaQuandoNaoEnviaCampoObrigatorioViaPost()
        {
            Assert.Equal("Campo obrigatório", Assert.Throws<ValidationException>(() => _usuarioService.Post(ObterNovoUsuarioIncompleto())).Message);
        }

        #endregion
    }
}
