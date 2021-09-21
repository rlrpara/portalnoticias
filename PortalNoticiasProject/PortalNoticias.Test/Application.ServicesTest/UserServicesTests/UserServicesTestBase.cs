using PortalNoticias.Domain.Entities;
using PortalNoticias.Services.ViewModels;
using System;
using System.Collections.Generic;

namespace PortalNoticias.Test.Application.ServicesTest.UserServicesTests
{
    public class UserServicesTestBase
    {
        public UsuarioViewModel ObterNovoUsuario() => new UsuarioViewModel()
        {
            Nome = "Rodrigo Ribeiro",
            Email = "rlr.para@gmail.com",
            Senha = "12345",
            CodigoPerfil = 1,
            isDelete = false
        };

        public UsuarioViewModel ObterNovoUsuarioIncompleto() => new UsuarioViewModel()
        {
            Nome = "Rodrigo Ribeiro"
        };

        public List<Usuario> ObterListaUsuarios()
        {
            return new List<Usuario>
            {
                new Usuario
                {
                    Codigo = 1,
                    Nome = "Rodrigo Ribeiro",
                    Email = "rlr.para@gmail.com",
                    Senha = "12345",
                    CodigoPerfil = 2,
                    DataCadastro = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    Removido = false
                }
            };
        }

        public Usuario ObterUsuario1() => new Usuario()
        {
            Codigo = 1,
            Nome = "Rodrigo Ribeiro",
            Email = "rlr.para@gmail.com",
            Senha = "12345",
            CodigoPerfil = 2,
            DataCadastro = DateTime.Now,
            DataAtualizacao = DateTime.Now,
            Removido = false
        };

        public Usuario ObterUsuarioNulo() => new Usuario()
        {
            Nome = "Rodrigo Ribeiro",
            Email = "rlr.para@gmail.com",
            Senha = "12345",
            CodigoPerfil = 2,
            DataCadastro = DateTime.Now,
            DataAtualizacao = DateTime.Now,
            Removido = false
        };
    }
}
