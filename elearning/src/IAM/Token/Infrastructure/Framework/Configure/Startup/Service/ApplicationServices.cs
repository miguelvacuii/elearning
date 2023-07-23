using elearning.src.IAM.Token.Application.Command.Create;
using elearning.src.IAM.Token.Application.Event;
using elearning.src.Shared.Infrastructure.Framework.Startup.Service;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.IAM.Token.Infrastructure.Framework.Configure.Startup.Service
{
    public class ApplicationServices : IService
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<CreateTokenCommandHandler>();
            services.AddScoped<CreateTokenUseCase>();
            services.AddScoped<SetTokenToHeaderWhenTokenCreatedHandler>();
        }
    }
}
