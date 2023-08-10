using elearning.src.IAM.User.Application.Command.SignUp;
using elearning.src.IAM.User.Application.Command.Update;
using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Infrastructure.Framework.Startup.Subscriber;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.IAM.User.Infrastructure.Framework.Configure.Startup.Subscriber
{
    public class SyncCommandSubscriber : ISubscriber
    {
        public void Setup(HttpContext context)
        {
            ICommandBus commandBus = context.RequestServices.GetRequiredService<ICommandBus>();

            SignUpUserCommandHandler signUpUserCommandHandler = context.RequestServices.GetRequiredService<SignUpUserCommandHandler>();
            commandBus.Subscribe(signUpUserCommandHandler);

            UpdateUserCommandHandler updateUserCommandHandler = context.RequestServices.GetRequiredService<UpdateUserCommandHandler>();
            commandBus.Subscribe(updateUserCommandHandler);
        }
    }
}
