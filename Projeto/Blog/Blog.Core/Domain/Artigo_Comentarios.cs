namespace Blog.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Artigo_Comentarios
    {
        [Key]
        public int id_artigo_comentario { get; set; }

        public int? id_artigo { get; set; }

        public int? id_usuario { get; set; }

        [Column(TypeName = "text")]
        public string conteudo { get; set; }

        public DateTime? data_criacao { get; set; }

        public DateTime? data_alteracao { get; set; }

        public bool? ativo { get; set; }

        public virtual Artigos Artigos { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
