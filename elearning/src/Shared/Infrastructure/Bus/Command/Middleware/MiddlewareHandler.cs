using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Domain.Bus.Command.Middleware;

namespace elearning.src.Shared.Infrastructure.Bus.Command.Middleware
{
    public abstract class MiddlewareHandler : IMiddlewareHandler
    {
        private IMiddlewareHandler nextHandler;

        public IMiddlewareHandler SetNext(IMiddlewareHandler handler)
        {
            nextHandler = handler;
            return handler;
        }

        public virtual void Handle(ICommand command)
        {
            nextHandler.Handle(command);
        }
    }
}

