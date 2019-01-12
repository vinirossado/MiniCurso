using MyHome.Interfaces.Domain;
using MyHome.Interfaces.Repos;
using MyHome.Interfaces.Repos.Base;
using MyHome.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Services.Base
{
    public class BaseService<T> : IBaseService<T> where T : IBaseDomain
    {
        #region Properties
        private readonly IBaseRepo<T> _repo;
        private IGaleriaRepo repo;
        #endregion

        #region Constructors
        public BaseService(IBaseRepo<T> repo) => _repo = repo;

        public BaseService(IGaleriaRepo repo)
        {
            this.repo = repo;
        }
        #endregion

        #region Methods
        public virtual T Find(long clienteAppId, long id) => _repo.Find(clienteAppId, id);

        public virtual IList<T> List(long clienteAppId) => _repo.List(clienteAppId);

        public virtual void Remove(long clienteAppId, long id)
        {
            var obj = Find(clienteAppId, id);
            _repo.Remove(obj);
        }

        protected virtual void Add(long clienteAppId, T obj)
        {
            _repo.Add(clienteAppId, obj);
        }

        protected virtual void Update(long clienteAppId, T obj)
        {
            _repo.Update(clienteAppId, obj);
        }

        public virtual long Save(long clienteAppId, T obj)
        {
            obj.ClienteAppId = clienteAppId;

            if (obj.Id == 0)
                Add(clienteAppId, obj);
            else
                Update(clienteAppId, obj);

            return obj.Id;

        }
        #endregion
    }
}
