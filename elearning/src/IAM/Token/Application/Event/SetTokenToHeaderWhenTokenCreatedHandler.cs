using System.Collections.Generic;
using elearning.src.Shared.Domain.Bus.Event;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace elearning.src.IAM.Token.Application.Event
{
    public class SetTokenToHeaderWhenTokenCreatedHandler : IEventHandler
    {
        private IHttpContextAccessor context;

        public SetTokenToHeaderWhenTokenCreatedHandler(IHttpContextAccessor context)
        {
            this.context = context;
        }

        public void Handle(DomainEvent domainEvent)
        {
            Dictionary<string, string> body = domainEvent.Body();
            context.HttpContext.Request.Headers[HeaderNames.Authorization] = body["hash"];
        }
    }
}
