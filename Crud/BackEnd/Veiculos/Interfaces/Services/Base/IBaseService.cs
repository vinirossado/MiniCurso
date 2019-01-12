using MyHome.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Interfaces.Services
{
    public interface IBaseService<T> where T : IBaseDomain
    {
        T Find(long clienteAppId, long id);
        IList<T> List(long clienteAppId);
        long Save(long clienteAppId, T obj);
        void Remove(long clienteAppId, long id);
    }
}
