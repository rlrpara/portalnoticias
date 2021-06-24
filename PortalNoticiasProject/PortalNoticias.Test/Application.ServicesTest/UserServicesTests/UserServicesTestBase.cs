using PortalNoticias.Domain.Entities;
using PortalNoticias.Services.ViewModels;
using System;
using System.Collections.Generic;

namespace PortalNoticias.Test.Application.ServicesTest.UserServicesTests
{
    public class UserServicesTestBase
    {
        public UsuarioViewModel ObterNovoUsuario() => new()
        {
            Nome = "Rodrigo Ribeiro",
            Email = "rlr.para@gmail.com",
            Senha = "12345",
            CodigoPerfil = 1,
            isDelete = false
        };

        public UsuarioViewModel ObterNovoUsuarioIncompleto() => new()
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
                    DataCriado = DateTime.Now,
                    DataAtualizacao = DateTime.Now,
                    IsDelete = false
                }
            };
        }

        public Usuario ObterUsuario1() => new()
        {
            Codigo = 1,
            Nome = "Rodrigo Ribeiro",
            Email = "rlr.para@gmail.com",
            Senha = "12345",
            CodigoPerfil = 2,
            DataCriado = DateTime.Now,
            DataAtualizacao = DateTime.Now,
            IsDelete = false
        };

        public Usuario ObterUsuarioNulo() => new()
        {
            Nome = "Rodrigo Ribeiro",
            Email = "rlr.para@gmail.com",
            Senha = "12345",
            CodigoPerfil = 2,
            DataCriado = DateTime.Now,
            DataAtualizacao = DateTime.Now,
            IsDelete = false
        };
    }
}
