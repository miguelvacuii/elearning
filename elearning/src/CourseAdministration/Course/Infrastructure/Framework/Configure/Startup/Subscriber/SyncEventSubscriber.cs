﻿using elearning.src.CourseAdministration.Course.Application.Event;
using elearning.src.CourseAdministration.Course.Domain.Event;
using elearning.src.Shared.Domain.Bus.Event;
using elearning.src.Shared.Infrastructure.Framework.Startup.Subscriber;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.CourseAdministration.Course.Infrastructure.Framework.Configure.Startup.Subscriber
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
            eventBus.Subscribe(
                context.RequestServices.GetRequiredService<SendEmailWhenCourseUpdatedEventHandler>(),
                CourseUpdatedEvent.NAME
            );
        }
    }
}
