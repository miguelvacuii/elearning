using System.Collections.Generic;
using elearning.src.Shared.Domain.Bus.Query;
using elearning.src.Shared.Infrastructure.Helper;
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
            string queryHandlerFullName = ObjectProperties.GetObjectFullName(queryHandler);
            queryHandlers.Add(queryHandlerFullName, queryHandler);
        }

        // TO-DO interfaz o middleware
        public void Authorize(IAuthorization authorization)
        {
            string authorizationHandlerFullName = ObjectProperties.GetObjectFullName(authorization);
            authorizationList.Add(authorizationHandlerFullName, authorization);
        }

        public IResponse Ask(IQuery query)
        {
            string requestNamespace = ObjectProperties.GetObjectNamespace(query);
            string requestName = ObjectProperties.GetObjectName(query);
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
    }
}