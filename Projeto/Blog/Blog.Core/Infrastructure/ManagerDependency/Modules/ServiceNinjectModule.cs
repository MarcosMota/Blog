using Blog.Core.Cache;
using Blog.Core.Data;
using Blog.Core.Data.Services.Security;
using Blog.Core.Data.Services.Usuario;
using Blog.Core.Domain;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Infrastructure.ManagerDependency.Modules
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepository<Permissoes>)).To(typeof(EfRepository<Permissoes>));

            //   kernel.Bind(typeof(IRepository<Usuarios>)).To(typeof(EfRepository<Permissoes>));
            //  var connection =new   NopNullCache();
            Bind<ICacheManager>().To<NopNullCache>();
            Bind<IUsuarioService>().To<UsuarioService>();
            Bind<IPermissionService>().To<PermissionService>();

        }
    }
}
