using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.Domain;
using Blog.Core.Cache;

namespace Blog.Core.Data.Services.Usuario
{
    public class UsuarioService: IUsuarioService
    {
        private const string CUSTOMERROLES_BY_SYSTEMNAME_KEY = "Blog.customerrole.systemname-{0}";
        private readonly IRepository<Usuarios> _usuarioRepository;
        private readonly IRepository<Usuarios_Permissoes> _customerRoleRepository;

        private readonly ICacheManager _cacheManager;

        public UsuarioService(IRepository<Usuarios> usuarioRepository,
            ICacheManager cacheManager)
        {
            this._usuarioRepository = usuarioRepository;
            _cacheManager = cacheManager;
        }

        public Usuarios GetUsuariosBySystemName(string systemName)
        {
            if (String.IsNullOrWhiteSpace(systemName))
                return null;

            string key = string.Format(CUSTOMERROLES_BY_SYSTEMNAME_KEY, systemName);
            return _cacheManager.Get(key, () =>
            {
                var query = from cr in _customerRoleRepository.Table
                            orderby cr.id_permissao
                            where cr.Permissoes.Sistema == systemName
                            select cr.Usuarios;
                var customerRole = query.FirstOrDefault();
                return customerRole;
            });
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

        public Permissoes GetPermissoesUsuariosBySystemName(string systemName)
        {
            if (String.IsNullOrWhiteSpace(systemName))
                return null;

            string key = string.Format(CUSTOMERROLES_BY_SYSTEMNAME_KEY, systemName);
            return _cacheManager.Get(key, () =>
            {
                var query = from cr in _customerRoleRepository.Table
                            orderby cr.id_permissao
                            where cr.Permissoes.Sistema == systemName
                            select cr;
                var customerRole = query.FirstOrDefault();
                return customerRole.Permissoes;
            });
        }

        public void InsertUsuarioRole(Permissoes customerRole)
        {
            if (customerRole == null)
                throw new ArgumentNullException("customerRole");
        }

        public Usuarios GetUsuarioBySistema(string systemName)
        {
            if (string.IsNullOrWhiteSpace(systemName))
                return null;

            var query = from c in _usuarioRepository.Table
                        select c;
            var customer = query.FirstOrDefault();
            return customer;
        }

        public Usuarios GetUsuarioById(int customerRoleId)
        {
            if (customerRoleId == 0)
                return null;

            return _customerRoleRepository.GetById(customerRoleId).Usuarios;
        }

        public Usuarios GetUsuarioByGuid(Guid customerGuid)
        {
            if (customerGuid == Guid.Empty)
                return null;

            var query = from c in _usuarioRepository.Table
                        select c;
            var customer = query.FirstOrDefault();
            return customer;
        }

        public Usuarios GetUsuarioByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            var query = from c in _usuarioRepository.Table
                        select c;
            var customer = query.FirstOrDefault();
            return customer;
        }
        
    }
}
