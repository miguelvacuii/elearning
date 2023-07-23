using Microsoft.AspNetCore.Http;

namespace elearning.src.Shared.Infrastructure.Framework.Startup.Subscriber
{
    public interface ISubscriber
    {
        void Setup(HttpContext context);
    }
}
