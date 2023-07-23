using elearning.src.IAM.Token.Application.Command.Create;
using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Infrastructure.Framework.Startup.Subscriber;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.IAM.Token.Infrastructure.Framework.Configure.Startup.Subscriber
{
    public class SyncCommandSubscriber : ISubscriber
    {
        public void Setup(HttpContext context)
        {
            ICommandBus commandBus = context.RequestServices.GetRequiredService<ICommandBus>();
            CreateTokenCommandHandler createTokenCommandHandler = context.RequestServices.GetRequiredService<CreateTokenCommandHandler>();
            commandBus.Subscribe(createTokenCommandHandler);
        }
    }
}
