namespace Blog.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Permissoes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Permissoes()
        {
            Usuarios_Permissoes = new HashSet<Usuarios_Permissoes>();
        }

        [Key]
        public int id_permissao { get; set; }

        [StringLength(100)]
        public string descricao_permissao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuarios_Permissoes> Usuarios_Permissoes { get; set; }
    }
}
