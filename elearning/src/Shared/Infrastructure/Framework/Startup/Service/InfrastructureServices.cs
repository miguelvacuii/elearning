using elearning.Shared.Infrastructure.Bus.Command.Middleware;
using elearning.Shared.Infrastructure.Bus.Event;
using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Domain.Bus.Event;
using elearning.src.Shared.Domain.Bus.Query;
using elearning.src.Shared.Infrastructure.Bus.Command;
using elearning.src.Shared.Infrastructure.Bus.Command.Middleware;
using elearning.src.Shared.Infrastructure.Bus.Event;
using elearning.src.Shared.Infrastructure.Bus.Query;
using elearning.src.Shared.Infrastructure.Persistence.Context;
using elearning.src.Shared.Infrastructure.Persistence.Repository;
using elearning.src.Shared.Infrastructure.Security.Authentication;
using elearning.src.Shared.Infrastructure.Security.Authentication.JWT;
using elearning.src.Shared.Infrastructure.Service.Hashing;
using elearning.src.Shared.Infrastructure.Service.JsonApi;
using elearning.src.Shared.Infrastructure.Service.Mailer;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.Shared.Infrastructure.Framework.Startup.Service
{
    public class InfrastructureServices
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<ELearningContext>();
            services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));
            services.AddScoped<ICommandBus, SyncCommandBus>();
            services.AddScoped<IQueryBus, QueryBus>();
            services.AddScoped<IEventBus, EventBusSync>();
            services.AddScoped<IDomainEventPublisher, DomainEventPublisherSync>();
            services.AddScoped<IEventProvider, EventProvider>();
            services.AddScoped<TransactionMiddleware>();
            services.AddScoped<EventDispatcherSyncMiddleware>();
            services.AddScoped<IHashing, DefaultHashing>();
            services.AddScoped<IMailer, Sendgrid>();
            services.AddScoped<IJsonApiEncoder, JsonApiEncoder>();
            services.AddScoped<IJWTEncoder, JWTEncoder>();
            services.AddScoped<IJWTDecoder, JWTDecoder>();
            services.AddScoped<OAuth>();
        }
    }
}
