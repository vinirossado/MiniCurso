using Microsoft.EntityFrameworkCore;
using MyHome.Infra.Data.Context;
using MyHome.Interfaces.Domain;
using MyHome.Interfaces.Repos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHome.Infra.Data.Base
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class, IBaseDomain
    {
        private DbContextOptions<DataContext> _options;

        public BaseRepo(DbContextOptions<DataContext> options) => _options = options;

        public virtual void Add(long clienteAppId, T obj)
        {
            using (var context = new DataContext(_options))
            {
                obj.ClienteAppId = clienteAppId;

                context.Set<T>().Add(obj);
                context.SaveChanges();
            }
        }

        public virtual IList<T> List(long clienteAppId)
        {
            using (var context = new DataContext(_options))
            {
                return context.Set<T>().Where(x => x.ClienteAppId == clienteAppId).ToList();
            }
        }

        public virtual IList<T> GetAll(string query = null)
        {
            using (var context = new DataContext(_options))
            {
                return context.Set<T>().ToList();
            }
        }

        public virtual T Find(long clienteAppId, long id)
        {
            using (var context = new DataContext(_options))
            {
                return context.Set<T>().FirstOrDefault(x => x.ClienteAppId == clienteAppId && x.Id == id);
            }
        }

        public virtual void Remove(T obj)
        {
            try
            {
                using (var context = new DataContext(_options))
                {
                    context.Set<T>().Remove(obj);
                    context.SaveChanges();
                }
            }
            catch (DbUpdateException)
            {
                throw new Exception("Não foi possivel remover esse registro pois já foi utilizado.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void Update(long clienteAppId, T obj)
        {
            using (var context = new DataContext(_options))
            {
                obj.ClienteAppId = clienteAppId;

                context.Set<T>().Update(obj);
                context.SaveChanges();
            }
        }
    }
}
