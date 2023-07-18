using elearning.src.IAM.Token.Domain;
using UserAggregate = elearning.src.IAM.User.Domain.User;

namespace elearning.src.IAM.Token.Infrastructure.Service.Token
{
    public class TokenAdapter {

        private readonly TokenFacade tokenFacade;
        private readonly TokenTranslator tokenTranslator;

        public TokenAdapter(
            TokenFacade tokenFacade,
            TokenTranslator tokenTranslator
        ) {
            this.tokenFacade = tokenFacade;
            this.tokenTranslator = tokenTranslator;
        }

        public Payload FindPayloadByEmailAndPassword(string email, string password) {
            UserAggregate user = tokenFacade.FindPayloadByEmailAndPassword(email, password);
            return tokenTranslator.FromRepresentationToPayload(user);
        }
    }
}
