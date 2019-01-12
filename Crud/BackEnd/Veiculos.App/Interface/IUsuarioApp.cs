using MyHome.app.Interface;
using MyHome.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.App.Interface
{
    public interface IUsuarioApp<T> : IBaseApp<T> where T : IUsuario
    {
        T FindByEmail(long clienteAppId, string email);
    }
}
