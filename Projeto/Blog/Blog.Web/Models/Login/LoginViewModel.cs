using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Models.Login
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Lembrar { get; set; }
    }
}