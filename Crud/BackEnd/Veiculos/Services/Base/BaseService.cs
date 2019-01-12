using System;
using System.Collections.Generic;
using System.Text;
using Veiculos.Interfaces.Domain;
using Veiculos.Interfaces.Repos.Base;
using Veiculos.Interfaces.Services;

namespace Veiculos.Services.Base
{

    public class BaseService<T> : IBaseService<T> where T : IBaseDomain
    {
        #region Properties
        private readonly IBaseRepo<T> _repo;
        #endregion

        #region Constructors
        public BaseService(IBaseRepo<T> repo) => _repo = repo;
        #endregion

        #region Methods
        public virtual T Find(long id) => _repo.Find(id);

        public virtual IList<T> List() => _repo.List();

        public virtual void Remove(long id)
        {
            var obj = Find(id);
            _repo.Remove(obj);
        }

        protected virtual void Add(T obj)
        {
            _repo.Add(obj);
        }

        protected virtual void Update(T obj)
        {
            _repo.Update(obj);
        }

        public virtual long Save(T obj)
        {
            if (obj.Id == 0)
                Add(obj);
            else
                Update(obj);

            return obj.Id;

        }
        #endregion
    }
}