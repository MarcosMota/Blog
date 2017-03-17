using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blog.Core.Infraestrutura.Manager_Dependency
{
    public class ResolverDependency : IDependencyResolver
    {
        private IKernel kernel;
        public ResolverDependency(IKernel kernel)
        {
            this.kernel = kernel;
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}
