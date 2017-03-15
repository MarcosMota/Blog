using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.Domain;
using Blog.Core.Domain.Security;
using Blog.Core.Data.Services.Usuario;

namespace Blog.Core.Data.Services.Security
{
    public class StandardPermissionProvider : IPermissionProvider
    {
        public static readonly Permissoes AccessarAdminPanel = new Permissoes { Nome = "Acessar area admin", Sistema = "AcessarAreaAdmin", Categoria = "Padrao" };
        public static readonly Permissoes ManagerArtigos = new Permissoes { Nome = "Gerenciar artigos", Sistema = "ManagerArtigos", Categoria = "Manager Artigos" };

        //Permissoes Publicas
        public static readonly Permissoes ComentarArtigos = new Permissoes { Nome = "Comentar artigos", Sistema = "ManagerArtigos", Categoria = "Manager Artigos" };

        public static readonly Permissoes BlogFechado = new Permissoes { Nome = "Area Publica. acessar blog fechado", Sistema = "BlogFechado", Categoria = "Publico" };

        public IEnumerable<DefaultPermission> GetDefaultPermissions()
        {
            return new[]
            {
                new DefaultPermission
                {
                    UsuarioRoleSystemName = SystemUsuarioRoleNames.Administradores,
                    PermissionRecords = new[]
                    {
                        AccessarAdminPanel,
                        ManagerArtigos
                    }
                },
                new DefaultPermission
                {
                    UsuarioRoleSystemName = SystemUsuarioRoleNames.Editores,
                    PermissionRecords = new[]
                    {
                        ManagerArtigos
                    }
                },
                new DefaultPermission
                {
                    UsuarioRoleSystemName = SystemUsuarioRoleNames.Registrados,
                    PermissionRecords = new[]
                    {
                        ComentarArtigos
                    }
                }
            };
        }

        public IEnumerable<Permissoes> GetPermissions()
        {
            return new[]
            {
                AccessarAdminPanel,
                BlogFechado
            };
        }
    }
}
