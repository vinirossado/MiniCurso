using MyHome.Interfaces.Repos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Interfaces.Repos
{
    public interface IClienteRepo : IBaseRepo<Cliente>
    {
        Cliente FindByEmail(long clienteAppId, string email);
        bool VerificarCPFExiste(long clienteAppId, long id, string cpf);
        bool VerificarEmailExiste(long clienteAppId, long id, string email);

    }
}
