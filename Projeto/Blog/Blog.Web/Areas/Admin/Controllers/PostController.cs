using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        // GET: Admin/Post

        public ActionResult Index()
        {
            @ViewBag.Title = "Post";
            return View();
        }

        public ActionResult Novo()
        {
            @ViewBag.Title = "Post";
            return View();
        }
        public ActionResult Editar(int id)
        {

            @ViewBag.Title = "Post";
            return View();
        }
    }
}