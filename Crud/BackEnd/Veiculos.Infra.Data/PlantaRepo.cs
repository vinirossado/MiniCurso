using Microsoft.EntityFrameworkCore;
using MyHome.Infra.Data.Base;
using MyHome.Infra.Data.Context;
using MyHome.Interfaces.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Infra.Data
{
    public class PlantaRepo : BaseRepo<Planta>, IPlantaRepo
    {
        private readonly DbContextOptions<DataContext> _options;
        public PlantaRepo(DbContextOptions<DataContext> options) : base(options)
        {
            _options = options;
        }

    }
}
