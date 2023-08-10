using System;
using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Infrastructure.Helper;
using elearning.src.Shared.Infrastructure.Security.Authorization;

namespace elearning.src.Shared.Infrastructure.Bus.Command.Middleware
{
    public class CommandAuthorizationMiddleware : MiddlewareHandler
    {
        private readonly ICommandAuthorization authorization;

        public CommandAuthorizationMiddleware(ICommandAuthorization authorization)
        {
            this.authorization = authorization;
        }

        public override void Handle(ICommand command)
        {
            string requestNamespace = ObjectProperties.GetObjectNamespace(command);
            string requestName = ObjectProperties.GetObjectName(command);

            string authorizationHandlerName = requestName.Replace("Command", "Authorization");
            string authorizationFullName = requestNamespace + "." + authorizationHandlerName;

            Type authorizationObject = Type.GetType(authorizationFullName);

            if (authorizationObject != null)
            {
                authorization.Authorize(command);
            }

            base.Handle(command);
        }
    }
}
