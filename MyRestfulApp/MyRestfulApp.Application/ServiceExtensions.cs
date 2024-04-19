namespace MyRestfulApp.Application
{
    using Microsoft.Extensions.DependencyInjection;
    using Mapper;
    using Services.MercadoLibreService.Concrete;
    using Services.MercadoLibreService.Interface;

    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
            services.AddScoped<IMercadoLibreService, MercadoLibreService>();
        }
    }
}