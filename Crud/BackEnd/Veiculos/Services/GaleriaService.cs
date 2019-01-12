using MyHome.Interfaces.Repos;
using MyHome.Interfaces.Repos.Base;
using MyHome.Interfaces.Services;
using MyHome.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Services
{
    public class GaleriaService : BaseService<Galeria>, IGaleriaService
    {
        private IGaleriaRepo _repo;
        public GaleriaService(IGaleriaRepo repo) : base(repo)
        {
            _repo = repo;
        }

        public override void Remove(long clienteAppId, long id)
        {
            var galeria = _repo.Find(clienteAppId, id);
            _repo.Remove(galeria);
        }
    }
}
