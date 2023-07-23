using elearning.src.Shared.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace elearning.src.Shared.Infrastructure.Framework.Startup.Service
{
    public class MySqlService
    {
        private readonly IConfiguration configuration;

        public MySqlService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Load(IServiceCollection services)
        {
            services.AddDbContextPool<ELearningContext>(options => options
                .UseMySql(configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging()
            );
        }
    }
}
