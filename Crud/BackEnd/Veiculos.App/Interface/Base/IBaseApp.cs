using Veiculos.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Veiculos.app.Interface
{
    public interface IBaseApp<T> where T : IBaseDomain
    {
        T Find(long id);
        IList<T> List();
        long Save(T obj);
        void Remove(long id);
    }
}
