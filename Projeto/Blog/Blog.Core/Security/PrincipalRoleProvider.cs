using Blog.Core.Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Blog.Core.Security
{
    public class PrincipalRoleProvider : RoleProvider
    {
        public EfDbContext _context =new EfDbContext();
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            
            var roles = (from article in _context.Permissoes
                        where article.Usuarios_Permissoes
                        .Any(c => c.Usuarios.email== username)
                        select article).Select(p=>p.Sistema);

            if (roles != null)
                return roles.ToArray();
            else
                return new string[] { };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            var roles = _context.Permissoes.Where(p => p.Sistema == roleName).Select(p=>p.Sistema);
            if (roles != null)
                return roles.ToArray();
            else
                return new string[] { };
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
