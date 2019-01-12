using MyHome.Interfaces.Repos;
using MyHome.Interfaces.Repos.Base;
using MyHome.Interfaces.Services;
using MyHome.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Services
{
    public class PlantaService : BaseService<Planta>, IPlantaService
    {
        public PlantaService(IPlantaRepo repo) : base(repo)
        {
        }
    }
}
