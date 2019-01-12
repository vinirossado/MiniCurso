using MyHome.Interfaces.Repos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Interfaces.Repos
{
    public interface IAdminRepo : IBaseRepo<Admin>
    {
        Admin FindByEmail(long clienteAppId, string email);
    }
}
