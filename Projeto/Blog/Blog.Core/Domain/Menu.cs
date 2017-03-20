using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Domain
{
    public class Menu
    {
        public string Nome { get; set; }
        public string Role { get; set; }
        public string icone { get; set; }

        public string Controller { get; set; }
        public string Action { get; set; }

    }
}
