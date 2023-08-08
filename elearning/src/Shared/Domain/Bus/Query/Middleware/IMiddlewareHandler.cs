namespace elearning.src.Shared.Domain.Bus.Query.Middleware
{
    public interface IMiddlewareHandler
    {
        IMiddlewareHandler SetNext(IMiddlewareHandler handler);
        IResponse Handle(IQuery query);
    }
}