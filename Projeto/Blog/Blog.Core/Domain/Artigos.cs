namespace Blog.Core.Domain
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Artigos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artigos()
        {
            Artigo_Comentarios = new HashSet<Artigo_Comentarios>();
            Artigos_MetaTags = new HashSet<Artigos_MetaTags>();
            Artigos_Tags = new HashSet<Artigos_Tags>();
        }

        [Key]
        public int id_artigo { get; set; }

        public int? id_usuario { get; set; }

        public int? id_categoria { get; set; }

        [StringLength(100)]
        public string titulo { get; set; }

        [StringLength(400)]
        public string descricao { get; set; }

        [StringLength(100)]
        public string meta_title { get; set; }
        [StringLength(50)]
        public string imagem { get; set; }

        [StringLength(100)]
        public string meta_description { get; set; }

        public DateTime? data_criacao { get; set; }

        public DateTime? data_alteracao { get; set; }

        [Column(TypeName = "text")]
        public string conteudo { get; set; }

        public bool? ativo { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Artigo_Comentarios> Artigo_Comentarios { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Artigos_MetaTags> Artigos_MetaTags { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Artigos_Tags> Artigos_Tags { get; set; }
        [JsonIgnore]
        public virtual Categorias Categorias { get; set; }
        [JsonIgnore]
        public virtual Usuarios Usuarios { get; set; }
    }
}
