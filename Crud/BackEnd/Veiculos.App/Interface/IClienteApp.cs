using MyHome.app.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.App.Interface
{
    public interface IClienteApp : IBaseApp<Cliente>
    {
        long Save(long clienteAppId, Cliente cliente, bool alterandoSenha);
    }
}
