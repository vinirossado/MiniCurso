using Microsoft.Extensions.DependencyInjection;

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

        }

        private static void AddServicesContainer(IServiceCollection services)
        {
        }
         
        private static void AddRepositoriesContainer(IServiceCollection services)
        {
        }

    }
}
