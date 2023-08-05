using System.Collections.Generic;
using elearning.src.Shared.Domain.Bus.Query;
using elearning.src.Shared.Infrastructure.Security.Authorization;

namespace elearning.src.Shared.Infrastructure.Bus.Query
{
    public class QueryBus : IQueryBus
    {
        private Dictionary<string, IQueryHandler> queryHandlers;
        private Dictionary<string, IAuthorization> authorizationList;

        public QueryBus()
        {
            queryHandlers = new Dictionary<string, IQueryHandler>();
            authorizationList = new Dictionary<string, IAuthorization>();
        }

        // TO-DO interfaz o middleware
        public void Subscribe(IQueryHandler queryHandler)
        {
            string queryHandlerFullName = GetObjectFullName(queryHandler);
            queryHandlers.Add(queryHandlerFullName, queryHandler);
        }

        // TO-DO interfaz o middleware
        public void Authorize(IAuthorization authorization)
        {
            string authorizationHandlerFullName = GetObjectFullName(authorization);
            authorizationList.Add(authorizationHandlerFullName, authorization);
        }

        public IResponse Ask(IQuery query)
        {
            string requestNamespace = GetObjectNamespace(query);
            string requestName = GetObjectName(query);
            string queryHandlerName = requestName.Replace("Query", "QueryHandler");
            string queryHandlerFullName = requestNamespace + "." + queryHandlerName;

            string authorizationHandlerName = requestName.Replace("Query", "Authorization");
            string authorizationFullName = requestNamespace + "." + authorizationHandlerName;

            if (authorizationList.ContainsKey(authorizationFullName)) {
                IAuthorization authorization = authorizationList[authorizationFullName];
                authorization.Authorize(query);
            }

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