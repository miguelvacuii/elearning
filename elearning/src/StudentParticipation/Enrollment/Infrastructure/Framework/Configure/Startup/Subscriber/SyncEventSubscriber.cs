using elearning.src.Shared.Domain.Bus.Event;
using elearning.src.Shared.Infrastructure.Framework.Startup.Subscriber;
using elearning.src.StudentParticipation.Enrollment.Application.Event;
using elearning.src.StudentParticipation.Enrollment.Domain.Event;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.StudentParticipation.Enrollment.Infrastructure.Framework.Configure.Startup.Subscriber
{
    public class SyncEventSubscriber : ISubscriber
    {
        public void Setup(HttpContext context)
        {
            IEventBus eventBus = context.RequestServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe(
                context.RequestServices.GetRequiredService<SendEmailWhenEnrollmentCreated>(),
                EnrollmentCreatedEvent.NAME
            );
        }
    }
}
