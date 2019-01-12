using MyHome.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Interfaces.Services
{
    public interface IUsuarioService<T> : IBaseService<T> where T : IUsuario
    {
        T FindByEmail(long clienteAppId, string email);
    }
}
