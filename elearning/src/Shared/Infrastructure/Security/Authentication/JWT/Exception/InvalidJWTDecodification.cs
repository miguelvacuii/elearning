using elearning.src.Shared.Domain.Exception;

namespace elearning.src.Shared.Infrastructure.Security.Authentication.JWT.Exception
{
    public class InvalidJWTDecodification : ErrorException
    {
        public InvalidJWTDecodification(string message) : base(message) { }

        public static InvalidJWTDecodification FromTokenUser()
        {
            return new InvalidJWTDecodification("token user does not exist.");
        }
    }
}