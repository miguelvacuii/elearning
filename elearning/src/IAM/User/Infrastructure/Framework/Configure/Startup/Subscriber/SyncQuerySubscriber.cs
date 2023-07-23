﻿using elearning.src.IAM.User.Application.Query.FindUserByCredentials;
using elearning.src.Shared.Domain.Bus.Query;
using elearning.src.Shared.Infrastructure.Framework.Startup.Subscriber;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.IAM.User.Infrastructure.Framework.Configure.Startup.Subscriber
{
    public class SyncQuerySubscriber : ISubscriber
    {
        public void Setup(HttpContext context)
        {
            IQueryBus queryBus = context.RequestServices.GetRequiredService<IQueryBus>();

            FindUserByCredentialsQueryHandler findUserByCredentialsQueryHandler = context.RequestServices.GetRequiredService<FindUserByCredentialsQueryHandler>();
            queryBus.Subscribe(findUserByCredentialsQueryHandler);
        }
    }
}
