using Ninject;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using Blog.Core.Infrastructure.ManagerDependency.Modules;

namespace Blog.Core.Infrastructure.ManagerDependency
{
    public class IoC
    {
        public IKernel Kernel { get; private set; }

        public IoC()
        {
            Kernel = GetNinjectModules();
        }

        public StandardKernel GetNinjectModules()
        {
            return new StandardKernel(
                new ServiceNinjectModule()
                );
        }
    }
}
