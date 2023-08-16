using elearning.src.CourseBackoffice.Domain.Service;
using elearning.src.CourseBackoffice.Domain.Specification;
using elearning.src.CourseBackoffice.Infrastructure.Service.Course;
using elearning.src.Shared.Domain.Specification;
using elearning.src.Shared.Infrastructure.Framework.Startup.Service;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.CourseBackoffice.Infrastructure.Framework.Configure.Startup.Service
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
