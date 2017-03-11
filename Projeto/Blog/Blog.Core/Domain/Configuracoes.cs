namespace Blog.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Configuracoes
    {
        [Key]
        public int id_configuracao { get; set; }

        [StringLength(100)]
        public string parametro { get; set; }

        [StringLength(100)]
        public string valor { get; set; }
    }
}
