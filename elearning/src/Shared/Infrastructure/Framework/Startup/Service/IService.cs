using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.Shared.Infrastructure.Framework.Startup.Service
{
    public interface IService
    {
        void Load(IServiceCollection services);
    }
}