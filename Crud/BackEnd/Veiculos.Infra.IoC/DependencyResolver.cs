using Microsoft.Extensions.DependencyInjection;
using Veiculos.app.Interface;
using Veiculos.App;
using Veiculos.App.Interface;
using Veiculos.Infra.Data;
using Veiculos.Interface;
using Veiculos.Interfaces.Repos;
using Veiculos.Interfaces.Services;
using Veiculos.Security;
using Veiculos.Services;
using OnAuth2.Interfaces;

namespace Veiculos.Infra.IoC
{
    public static class DependencyResolver
    {

        public static void AddInjectionContainer(this IServiceCollection services)
        {
            AddApplicationContainer(services);
            AddServicesContainer(services);
            AddRepositoriesContainer(services);
        }

        private static void AddApplicationContainer(IServiceCollection services)
        {

            services.AddTransient<IAdminApp, AdminApp>();
        }

        private static void AddServicesContainer(IServiceCollection services)
        {
            services.AddTransient<IAdminService, AdminService>();
        }
         
        private static void AddRepositoriesContainer(IServiceCollection services)
        {
            services.AddTransient<IAdminRepo, AdminRepo>();
        }

    }
}
