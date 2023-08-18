using elearning.src.CourseAdministration.Course.Domain;
using elearning.src.CourseAdministration.Course.Infrastructure.Persistence.Repository;
using elearning.src.Shared.Infrastructure.Framework.Startup.Service;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.CourseAdministration.Course.Infrastructure.Framework.Configure.Startup.Service
{
    public class InfrastructureServices : IService
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<ICourseRepository, CourseRepository>();
        }
    }
}
