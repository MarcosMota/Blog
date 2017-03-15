namespace Blog.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Permissoes:BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Permissoes()
        {
            Usuarios_Permissoes = new HashSet<Usuarios_Permissoes>();
        }

        [Key]
        public int id_permissao { get; set; }
        /// <summary>
        /// Gets or sets the permission name
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Gets or sets the permission system name
        /// </summary>
        public string Sistema { get; set; }

        /// <summary>
        /// Gets or sets the permission category
        /// </summary>
        public string Categoria { get; set; }

        /// <summary>
        /// Gets or sets discount usage history
        /// </summary>

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuarios_Permissoes> Usuarios_Permissoes { get; set; }
    }
}
