namespace MyRestfulApp.Application
{
    using Microsoft.Extensions.DependencyInjection;
    using Mapper;
    using Services.MercadoLibreService.Concrete;
    using Services.MercadoLibreService.Interface;
    using MyRestfulApp.Application.Services.MyRestfulAppService.Interface;
    using MyRestfulApp.Application.Services.MyRestfulAppService.Concrete;

    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
            services.AddScoped<IMercadoLibreService, MercadoLibreService>();
            services.AddScoped<IMyRestfulAppService, MyRestfulAppService>();
        }
    }
}