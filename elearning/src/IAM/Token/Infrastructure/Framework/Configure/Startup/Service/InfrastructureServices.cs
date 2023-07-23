using elearning.src.IAM.Token.Domain;
using elearning.src.IAM.Token.Infrastructure.Persistence.Repository;
using elearning.src.Shared.Infrastructure.Framework.Startup.Service;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.IAM.Token.Infrastructure.Framework.Configure.Startup.Service
{
    public class InfrastructureServices : IService
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<ITokenRepository, TokenRepository>();
        }
    }
}
