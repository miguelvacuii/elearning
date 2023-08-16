using elearning.src.IAM.User.Domain;
using elearning.src.IAM.User.Infrastructure.Persistence.Repository;
using elearning.src.IAM.User.Infrastructure.Persistence.Specification;
using elearning.src.Shared.Infrastructure.Framework.Startup.Service;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.IAM.User.Infrastructure.Framework.Configure.Startup.Service
{
    public class InfrastructureServices : IService
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserSpecificationFactory, UserSpecificationFactory>();
        }
    }
}
