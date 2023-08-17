using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Infrastructure.Framework.Startup.Subscriber;
using elearning.src.StudentParticipation.Enrollment.Application.Command;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.StudentParticipation.Enrollment.Infrastructure.Framework.Configure.Startup.Subscriber
{
    public class SyncCommandSubscriber : ISubscriber
    {
        public void Setup(HttpContext context)
        {
            ICommandBus commandBus = context.RequestServices.GetRequiredService<ICommandBus>();
            CreateEnrollmentCommandHandler createEnrollmentCommandHandler = context.RequestServices.GetRequiredService<CreateEnrollmentCommandHandler>();
            commandBus.Subscribe(createEnrollmentCommandHandler);
        }
    }
}
