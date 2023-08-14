using elearning.src.CourseBackoffice.Application.Event;
using elearning.src.CourseBackoffice.Domain.Event;
using elearning.src.Shared.Domain.Bus.Event;
using elearning.src.Shared.Infrastructure.Framework.Startup.Subscriber;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.CourseBackoffice.Infrastructure.Framework.Configure.Startup.Subscriber
{
    public class SyncEventSubscriber : ISubscriber
    {
        public void Setup(HttpContext context)
        {
            IEventBus eventBus = context.RequestServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe(
                context.RequestServices.GetRequiredService<SendEmailWhenCourseCreatedEventHandler>(),
                CourseCreatedEvent.NAME
            );
            eventBus.Subscribe(
                context.RequestServices.GetRequiredService<SendEmailWhenCoursePublishedEventHandler>(),
                CoursePublishedEvent.NAME
            );
        }
    }
}
