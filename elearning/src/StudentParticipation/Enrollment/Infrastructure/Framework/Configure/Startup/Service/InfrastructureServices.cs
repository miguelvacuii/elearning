using elearning.src.Shared.Infrastructure.Framework.Startup.Service;
using elearning.src.StudentParticipation.Enrollment.Infrastructure.Persistence.Repository;
using elearning.src.StudentParticipation.Enrollment.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.StudentParticipation.Enrollment.Infrastructure.Framework.Configure.Startup.Service
{
    public class InfrastructureServices : IService
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
        }
    }
}
