using Blog.Core;
using Blog.Core.Cache;
using Blog.Core.Data;
using Blog.Core.Data.Services.Security;
using Blog.Core.Data.Services.Usuario;
using Blog.Core.Domain;
using Blog.Core.Infrastructure;
using Ninject;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Framework.Controllers
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AdminAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        private readonly bool _dontValidate;


        public AdminAuthorizeAttribute()
            : this(false)
        {
        }

        public AdminAuthorizeAttribute(bool dontValidate)
        {
            this._dontValidate = dontValidate;
        }

        private void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }

        private IEnumerable<AdminAuthorizeAttribute> GetAdminAuthorizeAttributes(ActionDescriptor descriptor)
        {
            return descriptor.GetCustomAttributes(typeof(AdminAuthorizeAttribute), true)
                .Concat(descriptor.ControllerDescriptor.GetCustomAttributes(typeof(AdminAuthorizeAttribute), true))
                .OfType<AdminAuthorizeAttribute>();
        }

        private bool IsAdminPageRequested(AuthorizationContext filterContext)
        {
            var adminAttributes = GetAdminAuthorizeAttributes(filterContext.ActionDescriptor);
            if (adminAttributes != null && adminAttributes.Any())
                return true;
            return false;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (_dontValidate)
                return;

            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            if (OutputCacheAttribute.IsChildActionCacheActive(filterContext))
                throw new InvalidOperationException("You cannot use [AdminAuthorize] attribute when a child action cache is active");

            if (IsAdminPageRequested(filterContext))
            {
                if (!this.HasAdminAccess(filterContext))
                    this.HandleUnauthorizedRequest(filterContext);
            }
        }

        public virtual bool HasAdminAccess(AuthorizationContext filterContext)
        {
            var kernel = new StandardKernel();

            //var luke = kernel.Get<Jedi>();
            kernel.Bind<IAuthenticationService>().To<FormsAuthenticationService>();
            kernel.Bind<IWorkContext>().To<WebWorkContext>()
                .WithConstructorArgument("httpContext", ninjectContext => HttpContext.Current); ;
            // var permissionService = EngineContext.Current.Resolve<IPermissionService>();
            kernel.Bind(typeof(IRepository<Usuarios>)).To(typeof(EfRepository<Usuarios>));
          //  var repositorio = kernel.Get<EfRepository<Permissoes>>();
            var repositorioUsuario = kernel.Get<EfRepository<Usuarios>>();
            kernel.Bind<ICacheManager>().To<NopNullCache>();
            var usuarioService = kernel.Get<UsuarioService>();
            kernel.Bind<HttpContextBase>().ToConstructor(ctx => new HttpContextWrapper(HttpContext.Current)).InTransientScope();
            
            var _usuarioService = new ConstructorArgument("usuarioService", usuarioService);
            var authenticationService = new ConstructorArgument("authenticationService", kernel.Get<FormsAuthenticationService>(
                new IParameter[] { _usuarioService}
                ));
            var work = kernel.Get<WebWorkContext>(_usuarioService,authenticationService);
            
            var permissionRepository = new Ninject.Parameters.ConstructorArgument("permissionRepository", kernel.Get<EfRepository<Permissoes>>());
            var _work = new Ninject.Parameters.ConstructorArgument("workContext", work);
            
            var permissionService = kernel.Get<PermissionService>(permissionRepository, _usuarioService,_work);
            //EngineContext.Current.Resolve<IPermissionService>();
            bool result = permissionService.Authorize(StandardPermissionProvider.AccessarAdminPanel);
            return result;
        }
    }
}
