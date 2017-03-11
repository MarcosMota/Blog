using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blog.Core.Domain;
using Blog.Core;
using Rhino.Mocks;

namespace Blog.Tests.Services.Usuario
{
    [TestClass]
    public class UsuarioService
    {
        private readonly IRepository<Usuarios> _usuarioRepository;


        [TestMethod]
        public void Inserir()
        {
            Usuarios user = new Usuarios()
            {
                ativo = true,
                senha = "1234",
                nome = "marcos",
                data_alteracao = DateTime.Now,
                data_criacao = DateTime.Now,
                email = "nome@gmail.com"
            };

            var _repositorUsuario = MockRepository.GenerateMock<IRepository<Usuarios>>();
            _repositorUsuario.Insert(user);
        }
    }
}
