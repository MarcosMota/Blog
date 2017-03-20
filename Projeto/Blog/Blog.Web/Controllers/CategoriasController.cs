using Blog.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class CategoriasController : Controller
    {
        EfDbContext db = new EfDbContext();
        // GET: Categorias
        public PartialViewResult ListaCategorias()
        {
            var categorias = db.Categorias.OrderBy(p => p.descricao).Take(10);
            return PartialView(categorias);
        }
        
    }
}