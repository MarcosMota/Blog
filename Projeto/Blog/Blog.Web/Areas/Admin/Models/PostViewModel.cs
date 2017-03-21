using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Web.Areas.Admin.Models
{
    public class PostViewModel
    {
        public int id_post { get; set; }

        public int id_categoria { get; set; }


        public string titulo { get; set; }


        public string descricao { get; set; }


        public string meta_title { get; set; }
      
        public string imagem { get; set; }

     
        public string meta_description { get; set; }

        public DateTime? data_criacao { get; set; }

        public DateTime? data_alteracao { get; set; }
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }

        public string conteudo { get; set; }

        public bool ativo { get; set; }
    }
}