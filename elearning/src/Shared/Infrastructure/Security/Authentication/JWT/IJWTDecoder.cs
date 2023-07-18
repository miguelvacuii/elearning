using elearning.src.Shared.Domain;

namespace elearning.src.Shared.Infrastructure.Security.Authentication.JWT
{
    public interface IJWTDecoder
    {
        AuthUser Decode();
    }
}