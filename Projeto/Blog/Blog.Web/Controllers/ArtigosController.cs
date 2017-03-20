using Blog.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class ArtigosController : Controller
    {
        EfDbContext db = new EfDbContext();
        // GET: Artigos
        public ActionResult Post(int id=0)
        {
            var post = db.Artigos.FirstOrDefault(a => a.id_artigo == id);
            return View(post);
        }
        public ActionResult GetCategoria(int categoria)
        {
            var artigos = db.Artigos
                .Where(a => a.id_categoria == categoria)
                .OrderBy(a => a.data_criacao);
            return View(artigos);
        }

    }
}