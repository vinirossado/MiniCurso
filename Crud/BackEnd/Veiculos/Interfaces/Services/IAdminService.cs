using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Interfaces.Services
{
    public interface IAdminService : IUsuarioService<Admin>
    {
        long Save(long clienteAppId, Admin admin, bool alterandoSenha);
    }
}
