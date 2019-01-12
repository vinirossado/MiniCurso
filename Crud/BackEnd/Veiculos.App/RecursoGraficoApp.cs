using MyHome.app.Base;
using MyHome.App.Interface;
using MyHome.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.App
{
    public class RecursoGraficoApp : BaseApp<RecursoGrafico>, IRecursoGraficoApp
    {
        private readonly IRecursoGraficoService _recursoGraficoService;
        public RecursoGraficoApp(IRecursoGraficoService recursoGraficoService) : base(recursoGraficoService)
        {
            _recursoGraficoService = recursoGraficoService;
        }
    }
}
