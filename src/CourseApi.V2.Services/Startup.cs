using CourseApi.V2.Repositories.Implementations;
using CourseApi.V2.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CourseApi.V2.Services
{
    public static class Startup
    {
        public static void Initialize(IServiceCollection services)
        {
            Repositories.Startup.Initialize(services);
            services.AddSingleton<ICourseRepository, CourseRepository>();
        }
    }
}
