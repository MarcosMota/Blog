namespace Blog.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Logs
    {
        [Key]
        public int id_log { get; set; }

        public int? id_usuario { get; set; }

        [StringLength(400)]
        public string descricao { get; set; }

        public DateTime? data_criacao { get; set; }

        [StringLength(1)]
        public string prioridade { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
