namespace elearning.src.Shared.Domain.Bus.Command.Middleware
{
    public interface IMiddlewareHandler
    {
        IMiddlewareHandler SetNext(IMiddlewareHandler handler);
        void Handle(ICommand command);
    }
}
