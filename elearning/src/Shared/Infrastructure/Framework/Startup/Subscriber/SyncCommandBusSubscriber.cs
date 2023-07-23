using elearning.Shared.Infrastructure.Bus.Command.Middleware;
using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Infrastructure.Bus.Command.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.Shared.Infrastructure.Framework.Startup.Subscriber
{
    public class SyncCommandBusSubscriber : ISubscriber
    {
        public void Setup(HttpContext context)
        {
            ICommandBus commandBus = context.RequestServices.GetRequiredService<ICommandBus>();
            commandBus.AddMiddleware(context.RequestServices.GetRequiredService<TransactionMiddleware>());
            commandBus.AddMiddleware(context.RequestServices.GetRequiredService<EventDispatcherSyncMiddleware>());
        }
    }
}
