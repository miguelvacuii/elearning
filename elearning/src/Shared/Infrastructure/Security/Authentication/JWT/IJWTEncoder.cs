using elearning.src.IAM.Token.Domain;

namespace elearning.src.Shared.Infrastructure.Security.Authentication.JWT
{
    public interface IJWTEncoder
    {
        string Encode(Payload payload);
    }
}