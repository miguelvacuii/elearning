namespace elearning.src.Shared.Infrastructure.Security.Authorization
{
    public interface IAuthorization {
        void Authorize(dynamic request);
    }
}
