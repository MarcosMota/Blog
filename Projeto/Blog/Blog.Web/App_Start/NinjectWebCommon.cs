[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Blog.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Blog.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Blog.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Blog.Core.Security;
    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Security;
    using System.Data.Entity;
    using Core.Data;
    using System.Configuration;
    using Core.Domain;
    using Core;
    using Core.Data.Repositorio;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EfDbContext"].ConnectionString;
            kernel.Bind<DbContext>()
                .To<EfDbContext>()
                .InRequestScope()
                .WithConstructorArgument("connectionString", connectionString);

           // kernel.Bind<DbContext>().To<EfDbContext>();
            kernel.Bind<RoleProvider>().To<PrincipalRoleProvider>();
            kernel.Bind<EfDbContext>().ToSelf().InRequestScope();
            kernel.Bind<IRepository<Categorias>>().To<CategoriaRepositorio>();
        }        
    }
}
