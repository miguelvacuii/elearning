using elearning.src.CourseAdministration.Course.Application.Command.Create;
using elearning.src.CourseAdministration.Course.Application.Command.Publish;
using elearning.src.CourseAdministration.Course.Application.Command.Update;
using elearning.src.CourseAdministration.Course.Application.Event;
using elearning.src.CourseAdministration.Course.Application.Query.FindById;
using elearning.src.CourseAdministration.Course.Application.Query.Response;
using elearning.src.Shared.Infrastructure.Framework.Startup.Service;
using elearning.src.Shared.Infrastructure.Security.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.CourseAdministration.Course.Infrastructure.Framework.Configure.Startup.Service
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

            services.AddScoped<ICommandAuthorization, UpdateCourseAuthorization>();
            services.AddScoped<UpdateCourseCommandHandler>();
            services.AddScoped<UpdateCourseUseCase>();
            services.AddScoped<SendEmailWhenCourseUpdatedEventHandler>();

            services.AddScoped<FindCourseByIdQueryHandler>();
            services.AddScoped<FindCourseByIdUseCase>();
            services.AddScoped<CourseResponseConverter>();
        }
    }
}
