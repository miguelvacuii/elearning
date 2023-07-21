using elearning.src.IAM.Token.Domain;

namespace elearning.src.IAM.Token.Infrastructure.Service.Token
{
    public class TokenTranslator
    {
        public virtual Payload FromRepresentationToPayload(dynamic userResponse)
        {
            return new Payload(
                userResponse.id,
                userResponse.email,
                userResponse.firstName,
                userResponse.lastName,
                userResponse.role
            );
        }
    }
}
