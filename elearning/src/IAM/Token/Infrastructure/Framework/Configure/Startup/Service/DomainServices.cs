using elearning.src.IAM.Token.Infrastructure.Service.Token;
using elearning.src.Shared.Infrastructure.Framework.Startup.Service;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.IAM.Token.Infrastructure.Framework.Configure.Startup.Service
{
    public class DomainServices : IService
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<TokenFacade>();
            services.AddScoped<TokenTranslator>();
            services.AddScoped<TokenAdapter>();
        }
    }
}
