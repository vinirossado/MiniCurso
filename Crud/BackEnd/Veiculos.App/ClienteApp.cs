using MyHome.app.Base;
using MyHome.App.Interface;
using MyHome.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.App
{
    public class ClienteApp : BaseApp<Cliente>, IClienteApp
    {
        private readonly IClienteService _service;
        public ClienteApp(IClienteService service) : base(service) => _service = service;

        public override IList<Cliente> List(long clienteAppId)
        {
            return _service.List(clienteAppId);
        }
        public long Save(long clienteAppId, Cliente cliente, bool alterandoSenha)
        {
            return _service.Save(clienteAppId, cliente, alterandoSenha);
        }
    }
}
