using Veiculos.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Veiculos.Interfaces.Repos.Base
{
    public interface IBaseRepo<T> where T : IBaseDomain
    {
        T Find(long clienteAppId, long id);
        IList<T> List(long clienteAppId);
        void Add(long clienteAppId, T obj);
        void Update(long clienteAppId, T obj);
        void Remove(T obj);
    }
}
