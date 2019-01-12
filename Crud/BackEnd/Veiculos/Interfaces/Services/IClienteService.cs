using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Interfaces.Services
{
    public interface IClienteService : IUsuarioService<Cliente>
    {
        long Save(long clienteAppId, Cliente cliente, bool alterandoSenha);

    }
}
