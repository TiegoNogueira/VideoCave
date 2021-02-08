using Microsoft.Extensions.DependencyInjection;
using VC.Data.Contexts;
using VC.Data.Repositories;
using VC.Domain.Interfaces;
using VC.Services.Interfaces;
using VC.Services.Services;

namespace VC.Commom.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<ISearchService, SearchService>();

            // Infra - Data
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<VideoCaveContext>();
        }
    }
}