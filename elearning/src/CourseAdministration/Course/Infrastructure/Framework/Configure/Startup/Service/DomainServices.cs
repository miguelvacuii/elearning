using elearning.src.CourseAdministration.Course.Domain.Service;
using elearning.src.CourseAdministration.Course.Domain.Specification;
using elearning.src.CourseAdministration.Course.Infrastructure.Service.Course;
using elearning.src.Shared.Domain.Specification;
using elearning.src.Shared.Infrastructure.Framework.Startup.Service;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.CourseAdministration.Course.Infrastructure.Framework.Configure.Startup.Service
{
    public class DomainServices : IService
    {
        public void Load(IServiceCollection services) {
            services.AddScoped<CourseFinder>();
            services.AddScoped<CourseFacade>();
            services.AddScoped<CourseTranslator>();
            services.AddScoped<CourseAdapter>();
            services.AddScoped<ISpecification<Domain.Course>, TeacherExistSpecification>();
        }
    }
}
