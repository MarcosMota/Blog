using Blog.Web.Models.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class CommonController : Controller
    {
        // GET: Categorias
        public PartialViewResult AllCategoria()
        {
            List<CategoriaModel> model = new List<CategoriaModel>();
            CategoriaModel c1 = new CategoriaModel()
            {
                Descricao = "Categoria 1",
                IdCategoria = 1
            };
            CategoriaModel c2 = new CategoriaModel()
            {
                Descricao = "Categoria 2",
                IdCategoria = 2
            };
            CategoriaModel c3 = new CategoriaModel()
            {
                Descricao = "Categoria 3",
                IdCategoria = 3
            };
            model.Add(c1);
            model.Add(c2);
            model.Add(c3);
            return PartialView("_Categorias",model.OrderBy(c=>c.Descricao).Take(6));
        }



    }
}