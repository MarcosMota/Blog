using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.Domain;
namespace Blog.Core.Data.Services.Usuario
{
    public class UsuarioService
    {
        private readonly IRepository<Usuarios> _usuarioRepository;
        public UsuarioService(IRepository<Usuarios> usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
        }
        /// <summary>
        /// Inserts category
        /// </summary>
        /// <param name="Usuarios">Usuarios</param>
        public void Insert(Usuarios usuarios)
        {
            if (usuarios == null)
                throw new ArgumentNullException("usuarios");

            _usuarioRepository.Insert(usuarios);
        }

    }
}
