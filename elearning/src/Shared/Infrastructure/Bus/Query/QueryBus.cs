using System.Collections.Generic;
using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.src.Shared.Infrastructure.Bus.Query
{
    public class QueryBus : IQueryBus
    {
        private Dictionary<string, IQueryHandler> queryHandlers;

        public QueryBus()
        {
            queryHandlers = new Dictionary<string, IQueryHandler>();
        }

        public void Subscribe(IQueryHandler queryHandler)
        {
            string queryHandlerFullName = GetObjectFullName(queryHandler);
            queryHandlers.Add(queryHandlerFullName, queryHandler);
        }

        public IResponse Ask(IQuery query)
        {
            string requestNamespace = GetObjectNamespace(query);
            string requestName = GetObjectName(query);
            string queryHandlerName = requestName.Replace("Query", "QueryHandler");
            string queryHandlerFullName = requestNamespace + "." + queryHandlerName;

            IQueryHandler queryHandler = queryHandlers[queryHandlerFullName];
            return queryHandler.Handle(query);
        }

        // TO-DO refactorizar porque será código repetitivo al crer más commands
        public static string GetObjectFullName(object obj)
        {
            return obj.GetType().ToString();
        }

        public static string GetObjectNamespace(object obj)
        {
            return obj.GetType().Namespace;
        }

        public static string GetObjectName(object obj)
        {
            return obj.GetType().Name;
        }
    }
}