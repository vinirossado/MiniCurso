using Veiculos.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Veiculos.Interfaces.Repos.Base
{
    public interface IBaseRepo<T> where T : IBaseDomain
    {
        T Find(long id);
        IList<T> List();
        void Add(T obj);
        void Update(T obj);
        void Remove(T obj);
    }
}
