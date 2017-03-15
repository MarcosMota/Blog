using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class ArtigosController : Controller
    {
        // GET: Artigos
        public ActionResult Index()
        {
            return View();
        }
    }
}