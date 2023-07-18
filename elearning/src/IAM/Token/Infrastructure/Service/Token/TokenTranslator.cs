using elearning.src.IAM.Token.Domain;
using UserAggregate = elearning.src.IAM.User.Domain.User;

namespace elearning.src.IAM.Token.Infrastructure.Service.Token
{
    public class TokenTranslator
    {
        public Payload FromRepresentationToPayload(UserAggregate user)
        {
            return new Payload(
                 user.id.Value,
                 user.email.Value,
                 user.firstName.Value,
                 user.lastName.Value,
                 user.role.Value
            );
        }
    }
}

