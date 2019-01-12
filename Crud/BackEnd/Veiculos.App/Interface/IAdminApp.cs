using MyHome.app.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.App.Interface
{
    public interface IAdminApp : IBaseApp<Admin>
    {
        long SaveAdmin(long clienteAppId, Admin admin, bool alterandoSenha);
    }
}
