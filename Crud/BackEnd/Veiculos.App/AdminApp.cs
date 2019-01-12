using MyHome.app.Base;
using MyHome.App.Interface;
using MyHome.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.App
{
    public class AdminApp : BaseApp<Admin>, IAdminApp
    {
        private readonly IAdminService _service;

        public AdminApp(IAdminService service) : base(service) => _service = service;

        public long SaveAdmin(long clienteAppId, Admin admin, bool alterandoSenha)
        {
            return _service.Save(clienteAppId, admin, alterandoSenha);
        }
    }
}
