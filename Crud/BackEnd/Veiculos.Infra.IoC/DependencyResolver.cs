using Microsoft.Extensions.DependencyInjection;
using MyHome.app.Interface;
using MyHome.App;
using MyHome.App.Interface;
using MyHome.Infra.Data;
using MyHome.Interface;
using MyHome.Interfaces.Repos;
using MyHome.Interfaces.Services;
using MyHome.Security;
using MyHome.Services;
using OnAuth2.Interfaces;

namespace MyHome.Infra.IoC
{
    public static class DependencyResolver
    {

        public static void AddInjectionContainer(this IServiceCollection services)
        {
            AddApplicationContainer(services);
            AddServicesContainer(services);
            AddRepositoriesContainer(services);
            services.AddTransient<IConfiguration, Configuration>();
        }

        private static void AddApplicationContainer(IServiceCollection services)
        {

            services.AddTransient<IEmpreendimentoApp, EmpreendimentoApp>();
            services.AddTransient<IRecursoGraficoApp, RecursoGraficoApp>();
            services.AddTransient<IAdminApp, AdminApp>();
            services.AddTransient<IPlantaApp, PlantaApp>();
            services.AddTransient<IGaleriaApp, GaleriaApp>();
            services.AddTransient<IClienteApp, ClienteApp>();
            services.AddTransient<ILoginApp, LoginApp>();
        }

        private static void AddServicesContainer(IServiceCollection services)
        {

            services.AddTransient<IEmpreendimentoService, EmpreendimentoService>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IPlantaService, PlantaService>();
            services.AddTransient<IGaleriaService, GaleriaService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IClienteService, ClienteService>();
        }
         
        private static void AddRepositoriesContainer(IServiceCollection services)
        {
            services.AddTransient<IEmpreendimentoRepo, EmpreendimentoRepo>();
            services.AddTransient<IAdminRepo, AdminRepo>();
            services.AddTransient<IPlantaRepo, PlantaRepo>();
            services.AddTransient<IGaleriaRepo, GaleriaRepo>();
            services.AddTransient<IClienteRepo, ClienteRepo>();
        }

    }
}
