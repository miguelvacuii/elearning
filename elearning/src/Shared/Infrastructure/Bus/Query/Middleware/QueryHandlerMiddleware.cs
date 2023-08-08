using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.src.Shared.Infrastructure.Bus.Query.Middleware
{
    public class QueryHandlerMiddleware : MiddlewareHandler
    {
        private readonly IQueryHandler queryHandler;

        public QueryHandlerMiddleware(IQueryHandler queryHandler)
        {
            this.queryHandler = queryHandler;
        }

        public override IResponse Handle(IQuery query)
        {
            return queryHandler.Handle(query);
        }
    }
}