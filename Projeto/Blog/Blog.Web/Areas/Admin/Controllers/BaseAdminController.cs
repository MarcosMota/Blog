using Blog.Web.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class BaseAdminController: BaseController
    {
    }
}