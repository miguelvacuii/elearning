using elearning.src.IAM.User.Domain.Service;
using elearning.src.IAM.User.Domain.Specification;
using elearning.src.Shared.Domain.Specification;
using elearning.src.Shared.Infrastructure.Framework.Startup.Service;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.IAM.User.Infrastructure.Framework.Configure.Startup.Service
{
    public class DomainServices : IService
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<UniqueUser>();
            services.AddScoped<UserFinder>();
            services.AddScoped<UserExistSpecification>();
            services.AddScoped<ISpecification <Domain.User>, EmailExistSpecification>();
            services.AddScoped<ISpecification <Domain.User>, UserExistSpecification >();
        }
    }
}
