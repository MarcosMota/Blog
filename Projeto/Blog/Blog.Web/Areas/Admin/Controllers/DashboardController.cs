using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            @ViewBag.Title = "Dashboard";
            return View();
        }
    }
}