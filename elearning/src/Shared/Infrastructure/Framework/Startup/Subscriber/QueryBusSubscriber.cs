using elearning.src.Shared.Domain.Bus.Query;
using elearning.src.Shared.Infrastructure.Bus.Query.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.Shared.Infrastructure.Framework.Startup.Subscriber
{
    public class QueryBusSubscriber : ISubscriber
    {
        public void Setup(HttpContext context)
        {
            IQueryBus queryBus = context.RequestServices.GetRequiredService<IQueryBus>();
            queryBus.AddMiddleware(context.RequestServices.GetRequiredService<QueryAuthorizationMiddleware>());
        }
    }
}