using Blog.Core.Data;
using Blog.Core.Security;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Blog.Core.Infraestrutura.Manager_Dependency
{
    public class AutenticationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<EfDbContext>();
            Bind<RoleProvider>().To<PrincipalRoleProvider>();
        }
    }
}
