namespace MyRestfulApp.Data
{
    using Microsoft.Extensions.DependencyInjection;
    using Application.IRepositories.MercadoLibre;
    using ApiRepositories;
    using MyRestfulApp.Application.IRepositories.MyRestfulApp;

    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services)
        {
            services.AddScoped(typeof(IMercadoLibreRepository), typeof(MercadoLibreRepository));
            services.AddScoped(typeof(IMyRestfulAppRepository), typeof(MyRestfulAppRepository));
        }
    }
}