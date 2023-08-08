using elearning.src.Shared.Domain.Bus.Query;
using elearning.src.Shared.Domain.Bus.Query.Middleware;

namespace elearning.src.Shared.Infrastructure.Bus.Query.Middleware
{
    public abstract class MiddlewareHandler : IMiddlewareHandler
    {
        private IMiddlewareHandler nextHandler;

        public IMiddlewareHandler SetNext(IMiddlewareHandler handler)
        {
            nextHandler = handler;
            return handler;
        }

        public virtual IResponse Handle(IQuery query)
        {
            return nextHandler.Handle(query);
        }
    }
}