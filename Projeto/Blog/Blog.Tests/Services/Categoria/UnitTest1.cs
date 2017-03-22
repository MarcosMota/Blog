using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject.Web.Common;
using Blog.Core.Data;
using Ninject;
using Blog.Core;
using Blog.Core.Data.Repositorio;
using Blog.Core.Domain;
using System.Collections.Generic;

namespace Blog.Tests.Services.Categoria
{
    [TestClass]
    public class CategoriaTest
    {
        [TestMethod]
        public void Injection()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            var kernel = new StandardKernel();
            kernel.Bind<EfDbContext>().ToSelf().InRequestScope();

            kernel.Bind<IRepository<Categorias>>().To<CategoriaRepositorio>();

            var repositorio = kernel.Get<CategoriaRepositorio>();

            List<Categorias> list = repositorio.GetAll();

            Assert.AreNotEqual(list.Count, 0);


        }
    }
}
