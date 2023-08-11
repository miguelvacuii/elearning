using elearning.src.CourseBackoffice.Infrastructure.Service.Course;
using elearning.src.Shared.Infrastructure.Framework.Startup.Service;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.CourseBackoffice.Infrastructure.Framework.Configure.Startup.Service
{
    public class DomainServices : IService
    {
        public void Load(IServiceCollection services) {
            services.AddScoped<CourseFacade>();
            services.AddScoped<CourseTranslator>();
            services.AddScoped<CourseAdapter>();
        }
    }
}
