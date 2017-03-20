using Blog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Infraestrutura
{
    public class ManagerMenu
    {
        public static List<Menu> GetMenu()
        {
            List<Menu> list = new List<Menu>();
            Menu m1 = new Menu() { Nome = "Dashboard", Role = "Admin" ,icone= "fa fa-desktop fa-fw",Controller="Dashboard",Action="Index" };
            Menu m2 = new Menu() { Nome = "Post", Role = "Admin", icone = "fa fa-desktop fa-fw", Controller = "Post", Action = "Index" };
            Menu m3 = new Menu() { Nome = "Usuarios", Role = "Admin", icone = "fa fa-desktop fa-fw", Controller = "Usuarios", Action = "Index" };
            Menu m4 = new Menu() { Nome = "Seguranca", Role = "Admin", icone = "fa fa-desktop fa-fw", Controller = "Seguranca", Action = "Index" };
            list.Add(m1);
            list.Add(m2);
            list.Add(m3);
            list.Add(m4);

            return list;
        }
    }
}
