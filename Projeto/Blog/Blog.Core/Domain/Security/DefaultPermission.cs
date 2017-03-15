using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Domain.Security
{
    public class DefaultPermission
    {

        /// <summary>
        /// Gets or sets the customer role system name
        /// </summary>
        public string UsuarioRoleSystemName { get; set; }

        /// <summary>
        /// Gets or sets the permissions
        /// </summary>
        public IEnumerable<Permissoes> PermissionRecords { get; set; }
    }
}
