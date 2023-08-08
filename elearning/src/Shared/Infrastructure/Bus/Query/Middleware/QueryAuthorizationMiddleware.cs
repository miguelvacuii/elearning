using System;
using elearning.src.Shared.Domain.Bus.Query;
using elearning.src.Shared.Infrastructure.Helper;
using elearning.src.Shared.Infrastructure.Security.Authorization;

namespace elearning.src.Shared.Infrastructure.Bus.Query.Middleware
{
    public class QueryAuthorizationMiddleware : MiddlewareHandler {
        private readonly IAuthorization authorization;

        public QueryAuthorizationMiddleware(IAuthorization authorization) {
            this.authorization = authorization;
        }

        public override IResponse Handle(IQuery query)
        {
            string requestNamespace = ObjectProperties.GetObjectNamespace(query);
            string requestName = ObjectProperties.GetObjectName(query);

            string authorizationHandlerName = requestName.Replace("Query", "Authorization");
            string authorizationFullName = requestNamespace + "." + authorizationHandlerName;

            Type authorizationObject = Type.GetType(authorizationFullName);

            if (authorizationObject != null)
            {
                authorization.Authorize(query);
            }

            return base.Handle(query);
        }
    }
}
