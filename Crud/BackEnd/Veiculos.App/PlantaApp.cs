using MyHome.app.Base;
using MyHome.App.Interface;
using MyHome.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.App
{
    public class PlantaApp : BaseApp<Planta>, IPlantaApp
    {
        public PlantaApp(IPlantaService service) : base(service)
        {
        }
    }
}
