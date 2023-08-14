﻿using elearning.src.CourseBackoffice.Application.Command.Create;
using elearning.src.CourseBackoffice.Application.Command.Publish;
using elearning.src.CourseBackoffice.Application.Event;
using elearning.src.Shared.Infrastructure.Framework.Startup.Service;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.CourseBackoffice.Infrastructure.Framework.Configure.Startup.Service
{
    public class ApplicationServices : IService
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<CreateCourseCommandHandler>();
            services.AddScoped<CreateCourseUseCase>();
            services.AddScoped<SendEmailWhenCourseCreatedEventHandler>();

            services.AddScoped<PublishCourseCommandHandler>();
            services.AddScoped<PublishCourseUseCase>();
            services.AddScoped<SendEmailWhenCoursePublishedEventHandler>();
        }
    }
}