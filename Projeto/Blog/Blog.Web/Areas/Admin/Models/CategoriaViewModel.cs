using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Web.Areas.Admin.Models
{
    public class CategoriaViewModel
    {
        public int id_categoria { get; set; }
        public string descricao { get; set; }
    }
}