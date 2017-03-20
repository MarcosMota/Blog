using Blog.Core.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class CommonController : Controller
    {
        // GET: Admin/Common
        public ActionResult Menu()
        {
            return View(ManagerMenu.GetMenu());
        }
    }
}