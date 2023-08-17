using elearning.src.Shared.Domain.Specification;
using elearning.src.Shared.Infrastructure.Framework.Startup.Service;
using elearning.src.StudentParticipation.Enrollment.Domain;
using elearning.src.StudentParticipation.Enrollment.Domain.Specification;
using elearning.src.StudentParticipation.Enrollment.Infrastructure.Service.Enrollment;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.StudentParticipation.Enrollment.Infrastructure.Framework.Configure.Startup.Service
{
    public class DomainServices : IService
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<EnrollmenrFacade>();
            services.AddScoped<EnrollmentTranslator>();
            services.AddScoped<EnrollmentAdapter>();
            services.AddScoped<ISpecification<Domain.Enrollment>, CourseExistSpecification>();
            services.AddScoped<ISpecification<Domain.Enrollment>, StudentExistSpecification>();
            services.AddScoped<ISpecification<Domain.Enrollment>, EnrollmentNotExistSpecification>();
            services.AddScoped<ISpecification, CreateEnrollmentSpecificationFactory>();
        }
    }
}
