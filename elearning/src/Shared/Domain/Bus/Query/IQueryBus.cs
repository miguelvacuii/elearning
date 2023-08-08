using elearning.src.Shared.Domain.Bus.Query.Middleware;

namespace elearning.src.Shared.Domain.Bus.Query {
    public interface IQueryBus {
        void Subscribe(IQueryHandler queryHandler);
        IResponse Ask(IQuery query);
        void AddMiddleware(IMiddlewareHandler transactionMiddleware);
    }
}
