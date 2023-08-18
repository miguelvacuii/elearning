using elearning.src.CourseAdministration.Course.Application.Query.FindById;
using elearning.src.Shared.Domain.Bus.Query;
using elearning.src.Shared.Infrastructure.Framework.Startup.Subscriber;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.CourseAdministration.Course.Infrastructure.Framework.Configure.Startup.Subscriber
{
    public class QueryBusSubscriber : ISubscriber
    {
        public void Setup(HttpContext context)
        {
            IQueryBus queryBus = context.RequestServices.GetRequiredService<IQueryBus>();

            FindCourseByIdQueryHandler findCourseByIdQueryHandler = context.RequestServices.GetRequiredService<FindCourseByIdQueryHandler>();
            queryBus.Subscribe(findCourseByIdQueryHandler);
        }
    }
}
