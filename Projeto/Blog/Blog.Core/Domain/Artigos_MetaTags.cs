namespace Blog.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Artigos_MetaTags
    {
        [Key]
        public int id_artigo_tag { get; set; }

        public int? id_artigo { get; set; }

        public int? descricao { get; set; }

        public virtual Artigos Artigos { get; set; }
    }
}
