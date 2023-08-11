using elearning.src.CourseBackoffice.Domain;
using elearning.src.CourseBackoffice.Infrastructure.Persistence.Repository;
using elearning.src.Shared.Infrastructure.Framework.Startup.Service;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.CourseBackoffice.Infrastructure.Framework.Configure.Startup.Service
{
    public class InfrastructureServices : IService
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<ICourseRepository, CourseRepository>();
        }
    }
}
