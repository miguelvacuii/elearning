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
            IQueryBus QueryBus = context.RequestServices.GetRequiredService<IQueryBus>();
            QueryBus.AddMiddleware(context.RequestServices.GetRequiredService<QueryAuthorizationMiddleware>());
        }
    }
}