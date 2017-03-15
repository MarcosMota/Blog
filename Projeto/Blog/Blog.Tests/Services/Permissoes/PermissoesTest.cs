using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System.Security;
using Blog.Core.Data.Services.Security;
using Rhino.Mocks.Constraints;
using Blog.Core.Data.Services.Usuario;
using Blog.Core.Domain;
using Blog.Core;
using Blog.Core.Data;
using Ninject.Parameters;
using Blog.Core.Cache;

namespace Blog.Tests.Services.PermissoesTest
{
    [TestClass]
    public class PermissoesTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var kernel = new StandardKernel();  
           // kernel.Bind<IRepository<Usuarios>>().To<EfRepository<Usuarios>();
            kernel.Bind(typeof(IRepository<Usuarios>)).To(typeof(EfRepository<Usuarios>));
            kernel.Bind(typeof(IRepository<Permissoes>)).To(typeof(EfRepository<Permissoes>));

            //   kernel.Bind(typeof(IRepository<Usuarios>)).To(typeof(EfRepository<Permissoes>));
            //  var connection =new   NopNullCache();
            kernel.Bind<ICacheManager>().To<NopNullCache>();
            kernel.Bind<IUsuarioService>().To<UsuarioService>();
            kernel.Bind<IPermissionService>().To<PermissionService>();
            
            var luke = kernel.Get<PermissionService>();
            var result = luke.GetAllPermissionRecords();
            Assert.IsInstanceOfType(luke, typeof(PermissionService));
        }
    }
}
