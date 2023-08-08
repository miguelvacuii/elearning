using System.Collections.Generic;
using elearning.src.Shared.Domain.Bus.Query;
using elearning.src.Shared.Domain.Bus.Query.Middleware;
using elearning.src.Shared.Infrastructure.Bus.Query.Middleware;
using elearning.src.Shared.Infrastructure.Helper;

namespace elearning.src.Shared.Infrastructure.Bus.Query
{
    public class QueryBus : IQueryBus
    {
        private Dictionary<string, IQueryHandler> queryHandlers;
        private List<IMiddlewareHandler> middlewareHandlers;

        public QueryBus()
        {
            queryHandlers = new Dictionary<string, IQueryHandler>();
            middlewareHandlers = new List<IMiddlewareHandler>();
        }

        public void Subscribe(IQueryHandler queryHandler)
        {
            string queryHandlerFullName = ObjectProperties.GetObjectFullName(queryHandler);
            queryHandlers.Add(queryHandlerFullName, queryHandler);
        }

        public void AddMiddleware(IMiddlewareHandler middlewareHandler)
        {
            middlewareHandlers.Add(middlewareHandler);
        }

        public IResponse Ask(IQuery query)
        {
            string requestNamespace = ObjectProperties.GetObjectNamespace(query);
            string requestName = ObjectProperties.GetObjectName(query);
            string queryHandlerName = requestName.Replace("Query", "QueryHandler");
            string queryHandlerFullName = requestNamespace + "." + queryHandlerName;

            IQueryHandler queryHandler = queryHandlers[queryHandlerFullName];
            IMiddlewareHandler middlewareHandler = new QueryHandlerMiddleware(queryHandler);
            middlewareHandler = LoadHandlers(middlewareHandler);

            return middlewareHandler.Handle(query);
        }

        private IMiddlewareHandler LoadHandlers(IMiddlewareHandler middlewareHandler)
        {
            foreach (IMiddlewareHandler handler in middlewareHandlers)
            {
                handler.SetNext(middlewareHandler);
                middlewareHandler = handler;
            }

            return middlewareHandler;
        }
    }
}