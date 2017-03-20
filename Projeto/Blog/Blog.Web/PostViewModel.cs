using Blog.Core.Domain;
using Blog.Web.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web
{
    public class PostViewModel
    {
        public Paginacao Paginacao { get; set; }
        public Artigos  Posts { get; set; }
    }
}