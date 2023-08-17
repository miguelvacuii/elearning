using elearning.src.Shared.Infrastructure.Framework.Startup.Service;
using elearning.src.StudentParticipation.Enrollment.Application.Command;
using elearning.src.StudentParticipation.Enrollment.Application.Event;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.StudentParticipation.Enrollment.Infrastructure.Framework.Configure.Startup.Service
{
    public class ApplicationServices : IService
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<CreateEnrollmentCommandHandler>();
            services.AddScoped<CreateEnrollmentUseCase>();
            services.AddScoped<SendEmailWhenEnrollmentCreated>();
        }
    }
}
