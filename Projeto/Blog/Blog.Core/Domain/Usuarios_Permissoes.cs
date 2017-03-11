namespace Blog.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuarios_Permissoes
    {
        [Key]
        public int id_permissao_usuario { get; set; }

        public int? id_usuario { get; set; }

        public int? id_permissao { get; set; }

        public virtual Permissoes Permissoes { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
