using elearning.src.CourseBackoffice.Application.Command.Create;
using elearning.src.CourseBackoffice.Application.Command.Publish;
using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Infrastructure.Framework.Startup.Subscriber;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.CourseBackoffice.Infrastructure.Framework.Configure.Startup.Subscriber
{
    public class SyncCommandSubscriber : ISubscriber
    {
        public void Setup(HttpContext context)
        {
            ICommandBus commandBus = context.RequestServices.GetRequiredService<ICommandBus>();

            CreateCourseCommandHandler createCourseCommandHandler = context.RequestServices.GetRequiredService<CreateCourseCommandHandler>();
            commandBus.Subscribe(createCourseCommandHandler);

            PublishCourseCommandHandler publishCourseCommandHandler = context.RequestServices.GetRequiredService<PublishCourseCommandHandler>();
            commandBus.Subscribe(publishCourseCommandHandler);
        }
    }
}
