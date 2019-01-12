using Veiculos.app.Interface;
using Veiculos.Interfaces.Domain;
using Veiculos.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Veiculos.app.Base
{
    public class BaseApp<T> : IBaseApp<T> where T : class, IBaseDomain
    {
        #region Properties
        private readonly IBaseService<T> _service;
        #endregion

        #region Constructors
        public BaseApp(IBaseService<T> service) => _service = service;
        #endregion

        #region Methods
        public virtual T Find(long id) => _service.Find(id);

        public virtual IList<T> List() => _service.List();

        public virtual void Remove(long id) => _service.Remove(id);

        public virtual long Save(T obj) => _service.Save(obj);
        #endregion
    }
}
