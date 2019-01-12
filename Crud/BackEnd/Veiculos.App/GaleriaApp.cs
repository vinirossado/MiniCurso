using MyHome.app.Base;
using MyHome.App.Interface;
using MyHome.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.App
{
    public class GaleriaApp : BaseApp<Galeria>, IGaleriaApp
    {
        public GaleriaApp(IGaleriaService service) : base(service)
        {
        }
    }
}
