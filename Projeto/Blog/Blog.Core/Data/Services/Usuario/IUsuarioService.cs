using Blog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Data.Services.Usuario
{
    public interface IUsuarioService
    {
        Permissoes GetPermissoesUsuariosBySystemName(string systemName);

        void InsertUsuarioRole(Permissoes customerRole);
        Usuarios GetUsuarioBySistema(string searchEngine);
        Usuarios GetUsuarioById(int value);
        Usuarios GetUsuarioByGuid(Guid customerGuid);
        Usuarios GetUsuarioByEmail(string usernameOrEmail);
    }
}
